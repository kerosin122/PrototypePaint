using UnityEngine;

public class ConverterTexture : MonoBehaviour
{
    public Texture2D ResizeTexture(int targetX, int targetY, TextureFormat format, Texture texture, bool value)
    {
        var text = new Texture2D(targetX, targetY, format, value);
        var curTex = RenderTexture.active;
        var renTex = new RenderTexture(text.width, text.height, 32);

        Graphics.Blit(texture, renTex);
        RenderTexture.active = renTex;

        text.ReadPixels(new Rect(0, 0, text.width, text.height), 0, 0);
        text.Apply();

        RenderTexture.active = curTex;
        renTex.Release();
        Destroy(renTex);
        return text;
    }
}
