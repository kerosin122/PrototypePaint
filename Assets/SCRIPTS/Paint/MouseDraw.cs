using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDraw : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Camera _camera;
    [SerializeField] private Canvas _hostCanvas;
    [Range(2, 20)] public int penRadius = 10;
    [SerializeField] private SystemGrafity _systemGrafity;
    public Color32 penColour = new(0, 0, 0, 255);
    public Color32 backroundColour = new(0, 0, 0, 0);
    [SerializeField] private Image _penPointer;
    public bool IsEraser = false;
    private bool _isInFocus = false;
    public bool IsInFocus
    {
        get => _isInFocus;
        private set
        {
            if (value != _isInFocus)
            {
                _isInFocus = value;
                TogglePenPointerVisibility(value);
            }
        }
    }
    private float _scaleFactor;
    private RawImage m_image;
    private Vector2? m_lastPos;

    private void Start()
    {
        _camera = Camera.main;
        Init();
    }
    private void OnEnable()
    {
        m_image = transform.GetComponent<RawImage>();
        TogglePenPointerVisibility(false);
    }
    private void Update()
    {
        var pos = Input.mousePosition;

        if (IsInFocus)
        {
            SetPenPointerPosition(pos);

            if (Input.GetMouseButton(0))
                WritePixels(pos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_lastPos = null;
            if (_systemGrafity.CheckQuantityPixelsPainted(m_image.texture as Texture2D))
            {
                _camera.backgroundColor = Color.green;
                Debug.Log("Uspeh");
            }
        }
    }
    private void Init()
    {
        _scaleFactor = _hostCanvas.scaleFactor * 7;
        var text = ResizeTexture(Convert.ToInt32(Screen.width / _scaleFactor), Convert.ToInt32(Screen.height / _scaleFactor), TextureFormat.RGBA32, false);
        _systemGrafity.GetGrafityPixels(text);///
        text.filterMode = FilterMode.Point;
        m_image.texture = text;
    }

    private Texture2D ResizeTexture(int targetX, int targetY, TextureFormat format, bool value)
    {
        var text = new Texture2D(targetX, targetY, format, value);
        var curTex = RenderTexture.active;
        var renTex = new RenderTexture(text.width, text.height, 32);

        Graphics.Blit(m_image.texture, renTex);
        RenderTexture.active = renTex;

        text.ReadPixels(new Rect(0, 0, text.width, text.height), 0, 0);
        text.Apply();

        RenderTexture.active = curTex;
        renTex.Release();
        Destroy(renTex);
        return text;
    }

    private void WritePixels(Vector2 pos)
    {

        pos /= _scaleFactor;
        var tex2d = new Texture2D(m_image.texture.width, m_image.texture.height, TextureFormat.RGBA32, false);

        var curTex = RenderTexture.active;
        var renTex = new RenderTexture(m_image.texture.width, m_image.texture.height, 32);

        Graphics.Blit(m_image.texture, renTex);
        RenderTexture.active = renTex;

        tex2d.ReadPixels(new Rect(0, 0, m_image.texture.width, m_image.texture.height), 0, 0);

        var col = IsEraser ? backroundColour : penColour;
        var positions = m_lastPos.HasValue ? GetLinearPositions(m_lastPos.Value, pos) : new List<Vector2>() { pos };

        foreach (var position in positions)
        {
            var pixels = GetNeighbouringPixels(new Vector2(m_image.texture.width, m_image.texture.height), position, penRadius);

            if (pixels.Count > 0)
                foreach (var p in pixels)
                    tex2d.SetPixel((int)p.x, (int)p.y, col);
        }

        tex2d.Apply();

        RenderTexture.active = curTex;
        renTex.Release();
        Destroy(renTex);
        curTex = null;
        renTex = null;

        m_image.texture = tex2d;
        m_lastPos = pos;
    }

    // [ContextMenu("Clear Texture")]
    // public void ClearTexture()
    // {
    //     var mainTex = m_image.texture;
    //     var tex2d = new Texture2D(mainTex.width, mainTex.height, TextureFormat.RGBA32, false);

    //     for (int i = 0; i < tex2d.width; i++)
    //     {
    //         for (int j = 0; j < tex2d.height; j++)
    //         {
    //             tex2d.SetPixel(i, j, backroundColour);
    //         }
    //     }

    //     tex2d.Apply();
    //     m_image.texture = tex2d;
    // }
    private List<Vector2> GetNeighbouringPixels(Vector2 textureSize, Vector2 position, int brushRadius)
    {
        var pixels = new List<Vector2>();

        for (int x = -brushRadius; x < brushRadius; x++)
        {
            for (int y = -brushRadius; y < brushRadius; y++)
            {
                var pxl = new Vector2(position.x + x, position.y + y);
                if (pxl.x > 0 && pxl.x < textureSize.x && pxl.y > 0 && pxl.y < textureSize.y)
                    pixels.Add(pxl);
            }
        }

        return pixels;
    }
    private List<Vector2> GetLinearPositions(Vector2 firstPos, Vector2 secondPos, int spacing = 2)
    {
        var positions = new List<Vector2>();

        var dir = secondPos - firstPos;

        if (dir.magnitude <= spacing)
        {
            positions.Add(secondPos);
            return positions;
        }

        for (int i = 0; i < dir.magnitude; i += spacing)
        {
            var v = Vector2.ClampMagnitude(dir, i);
            positions.Add(firstPos + v);
        }

        positions.Add(secondPos);
        return positions;
    }
    public void SetPenColour(Color32 color) => penColour = color;
    public void SetPenRadius(int radius) => penRadius = radius;
    private void SetPenPointerSize()
    {
        var rt = _penPointer.rectTransform;
        rt.sizeDelta = new Vector2(penRadius * 5, penRadius * 5);
    }
    private void SetPenPointerPosition(Vector2 pos)
    {
        _penPointer.transform.position = pos;
    }
    private void TogglePenPointerVisibility(bool isVisible)
    {
        if (isVisible)
            SetPenPointerSize();

        _penPointer.gameObject.SetActive(isVisible);
        Cursor.visible = !isVisible;
    }
    public void OnPointerEnter(PointerEventData eventData) => IsInFocus = true;
    public void OnPointerExit(PointerEventData eventData) => IsInFocus = false;

    // public void ExportSketch(string targetDirectory, string fileName)
    // {
    //     var dt = DateTime.Now.ToString("yyMMdd_hhmmss");
    //     fileName += $"_{dt}";

    //     targetDirectory = Path.Combine(targetDirectory, "Pixel Drawings");

    //     var mainTex = m_image.texture;
    //     var tex2d = new Texture2D(mainTex.width, mainTex.height, TextureFormat.RGBA32, false);

    //     var curTex = RenderTexture.active;
    //     var renTex = new RenderTexture(mainTex.width, mainTex.height, 32);

    //     Graphics.Blit(mainTex, renTex);
    //     RenderTexture.active = renTex;

    //     tex2d.ReadPixels(new Rect(0, 0, mainTex.width, mainTex.height), 0, 0);

    //     tex2d.Apply();

    //     RenderTexture.active = curTex;
    //     Destroy(renTex);
    //     curTex = null;
    //     renTex = null;
    //     mainTex = null;

    //     var png = tex2d.EncodeToPNG();

    //     if (!Directory.Exists(targetDirectory))
    //         Directory.CreateDirectory(targetDirectory);

    //     var fp = Path.Combine(targetDirectory, fileName + ".png");

    //     if (File.Exists(fp))
    //         File.Delete(fp);

    //     File.WriteAllBytes(fp, png);

    //     System.Diagnostics.Process.Start(targetDirectory);
    // }
}
