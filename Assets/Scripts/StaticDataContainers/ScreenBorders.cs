using UnityEngine;
public static class ScreenBorders
{
    private static float ScreenCentre;
    public static float HalfCamWidth { get; private set; }
    public static float Left { get; private set; }
    public static float Right { get; private set; }
    public static float Top { get; private set; }
    public static float Bottom { get; private set; }
    [RuntimeInitializeOnLoadMethod]
    public static void CalculateScreenBorders()
    {
        ScreenCentre = Camera.main.transform.position.x;
        //эти хаки с плюс 1 вызваны расположение камеры не по центру. 
        Top = Camera.main.orthographicSize + 1;
        Bottom = ScreenCentre - Top + 2;
        HalfCamWidth = Top * Camera.main.aspect;
        Left = ScreenCentre - HalfCamWidth; 
        Right = ScreenCentre + HalfCamWidth;
    }
}
