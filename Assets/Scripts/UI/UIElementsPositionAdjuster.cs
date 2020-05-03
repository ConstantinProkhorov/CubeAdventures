using UnityEngine;
/// <summary>
/// Adjusts position of given gameObject, so that it will not fall outside screenborders.
/// </summary>
//хорошо ли здесь использовать статический класс? я не знаю. я буду пихать их везде, пока не обнаружу подводные камни.!!!
public static class UIElementsPositionAdjuster/* : MonoBehaviour*/
{
    private static Vector3[] elementCornenrs = new Vector3[4];
    /// <summary>
    /// Adjusts position of given gameObject, so that it will not fall outside screenborders.
    /// </summary>
    /// <param name="rectTransform">RectTransform of gameObject.</param>
    /// <returns>Adjusted Vector3 position.</returns>
    public static Vector3 GetAdjustedPosition(RectTransform rectTransform)
    {
        //это магическое число уменьшает полученную дельту.
        //Видимо это связано с локальными координатами, но я точно не знаю и не могу обойти это другим, менее кривым способом. 
        int magicalNumber = 5;
        Vector3 AdjustedPosition = rectTransform.transform.position;
        rectTransform.GetWorldCorners(elementCornenrs);
        //Debug.Log(elementCornenrs[2].x);
        //Debug.Log(elementCornenrs[2].y);
        if (elementCornenrs[0].y < ScreenBorders.Bottom)
        {
            float positionDelta = ScreenBorders.Bottom - elementCornenrs[0].y;
            Debug.Log(positionDelta);
            AdjustedPosition.y += positionDelta * 2;
            return AdjustedPosition;
        }
        else if (elementCornenrs[1].x < ScreenBorders.Left)
        {

            return AdjustedPosition;
        }
        else if (elementCornenrs[2].x > ScreenBorders.Right)
        {
            float positionDelta = elementCornenrs[2].x - ScreenBorders.Left;

           
            Debug.Log(positionDelta);
            AdjustedPosition.x -= positionDelta / magicalNumber;
            return AdjustedPosition;
        }
        return AdjustedPosition;
    }
}
