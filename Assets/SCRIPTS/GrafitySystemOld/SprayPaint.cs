using System;
using UnityEngine;
public class SprayPaint : MonoBehaviour
{
    [Range(10, 100)][SerializeField] private float _brushSize;
    // [SerializeField] private float _brusSizeMin = 3;
    [SerializeField] private Texture2D _brushTexture;
    [SerializeField] private Texture2D _textureOld;
    [SerializeField] private Color _color;

    [SerializeField] private DrawZone _drawZona;
    // [SerializeField] private SystemGrafity _systemGrafity;
    // private Color _brushColor = Color.black;
    private Material _material;
    // public float MaxDistance { get; set; }
    public Action<Color> ChangedColor;

    private void Awake()
    {
        _material = new Material(Shader.Find("Hidden/DrawOnTexture"));
        _material.SetTexture("_BrushTexture", _brushTexture);
    }

    public void Draw(Vector2 POS)
    {
        Debug.Log("afssaf");
        // if (Input.GetMouseButton(0))
        // {
        // if (hit.collider.TryGetComponent<DrawZone>(out var drawZone))
        // {
        Vector2 textCoord = POS;
        // SetSettingBrush(hit.point);
        // float interpolant = Mathf.InverseLerp(MaxDistance, 0, GetPositionRayCast(hit.point));
        // drawZone.DrawTexture = DrawOnTextureGPU(drawZone.DrawTexture, textCoord, _brushColor, interpolant);
        _drawZona.DrawTexture = DrawOnTextureGPU(_drawZona.DrawTexture, textCoord, _color);
        // }
        // }
    }

    RenderTexture DrawOnTextureGPU(Texture src, Vector2 texCoord, Color newColor)
    {
        _material.SetVector("_BrushPosition", texCoord);
        _material.SetFloat("_BrushSize", _brushSize / src.width);
        _material.SetColor("_BrushColor", newColor);
        _material.SetFloat("_BrushTransparency", 1);

        // RenderTexture copiedTexture = new(src.width, src.height, 32);
        RenderTexture copiedTexture = new(128, 128, 32);
        Graphics.Blit(src, copiedTexture, _material);
        DestroyImmediate(src);
        return copiedTexture;
    }

    // private void SetSettingBrush(Vector3 hitPos)
    // {
    //     SetSizeBrush(GetPositionRayCast(hitPos));
    // }

    // private float GetPositionRayCast(Vector3 rayPoint)
    // {
    //     return Vector3.Distance(transform.position, rayPoint);
    // }

    // private void SetSizeBrush(float distance)
    // {
    //     _brushSize = _brusSizeMin + distance * 10;
    // }

}
