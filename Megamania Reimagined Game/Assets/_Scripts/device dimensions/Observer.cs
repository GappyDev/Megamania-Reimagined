using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Observer
{
    public static Vector2 getScreenDimensions()
    {
        Camera cam = Camera.main;
        float height , width,aspectRatio;
        height = cam.orthographicSize * 2;
        aspectRatio = cam.pixelWidth / (float)cam.pixelHeight;
        width = height * aspectRatio;
        return new Vector2(width,height);
    }
}
