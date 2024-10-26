
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class DrawZone : MonoBehaviour
{
    public MeshRenderer MeshRenderer { get; private set; }
    Texture initialTexture;
    Texture2D _texture2D;


    public virtual Texture DrawTexture
    {
        get => MeshRenderer.material.mainTexture;
        set => MeshRenderer.material.mainTexture = value;
    }


    private void Start()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
        if (DrawTexture)
        {
            _texture2D = DrawTexture as Texture2D;
        }
        initialTexture = DrawTexture;
        CreateTexture();
    }

    public void CreateTexture()
    {
        if (initialTexture == null)
        {
            DrawTexture = new Texture2D(1000, 1000, TextureFormat.RGBA32, true);
            _texture2D = DrawTexture as Texture2D;
            initialTexture = DrawTexture;
        }
        RenderTexture rt = new(initialTexture.width, initialTexture.height, 0)
        {
            filterMode = FilterMode.Point
        };
        RenderTexture.active = rt;
        Graphics.Blit(initialTexture, rt);
        DrawTexture = rt;
    }
}
