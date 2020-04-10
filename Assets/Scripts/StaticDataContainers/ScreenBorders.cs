using UnityEngine;
public static class ScreenBorders
{
    private static float ScreenCentre;
    public static float HalfCamWidth { get; private set; }
    public static float Left { get; private set; }
    public static float Right { get; private set; }
    public static float Top { get; private set; }
    public static float Buttom { get; private set; }
    [RuntimeInitializeOnLoadMethod]
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
