using System;
using System.Collections.Generic;
using UnityEngine;


public class SystemGrafity : MonoBehaviour
{
    private List<Vector2> _positionPixelsGrafity = new();
    public Action GraffitiIsDrawn;

    public void GetGrafityPixels(Texture2D text)
    {
        int i = 0;
        for (int x = 0; x < text.width; x++)
        {
            for (int y = 0; y < text.height; y++)
            {
                if (text.GetPixel(x, y) == Color.black)
                {
                    _positionPixelsGrafity.Add(new Vector2(x, y));
                    i++;
                }
            }
        }
    }

    public bool CheckQuantityPixelsPainted(Texture2D text)
    {
        int _cunterPixelNumber = 0;
        foreach (var pixelPos in _positionPixelsGrafity)
        {
            if (text.GetPixel((int)pixelPos.x, (int)pixelPos.y) != Color.black)
            {
                _cunterPixelNumber++;
            }
        }

        float percentPaint = Mathf.InverseLerp(0, _positionPixelsGrafity.Count, _cunterPixelNumber);
        if (percentPaint >= 0.95)
        {
            return true;
        }
        return false;
    }
}
