using UnityEngine;

public static class ScreenBorders
{
    public static float ScreenCentre { get; private set; }
    public static float HalfCamWidth { get; set; }
    public static float Left { get; set; }
    public static float Right { get; set; }
    public static float Top { get; set; }
    public static float Buttom { get; set; }

    public static void CalculateScreenBorders()
    {
        ScreenCentre = Camera.main.transform.position.x;
        Top = Camera.main.orthographicSize;
        Buttom = ScreenCentre - Top;
        HalfCamWidth = Top * Camera.main.aspect; 
        Left = ScreenCentre - HalfCamWidth; 
        Right = ScreenCentre + HalfCamWidth;
    }
}
