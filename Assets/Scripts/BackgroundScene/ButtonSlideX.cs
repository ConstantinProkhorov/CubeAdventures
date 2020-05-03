using UnityEngine;
using GameWork.Unity.Directions;

public class ButtonSlideX : MonoBehaviour
{
    [SerializeField] private RectTransform rec = null;
    private Vector2 DefaultOffsetMin, DefaultOffsetMax;
    [SerializeField] private float speed = default;
    [SerializeField] private float checkPosON = 0f;
    [SerializeField] private float checkPosLeft = -150f;

	void Start()
    {
        DefaultOffsetMin = new Vector2(rec.offsetMin.x, rec.offsetMin.y);
        DefaultOffsetMax = new Vector2(rec.offsetMax.x, rec.offsetMax.y);
    }

    void Update()
    {
        if (PauseButton.PauseClick == true )
        {
            if (rec.offsetMin.x < checkPosON)
            {
                MoveMenuButtonsX(HorizontalDirection.right);
            }

        }
        else if (PauseButton.PauseClick == false)
        {
            if (rec.offsetMin.x > checkPosLeft)
            {
                MoveMenuButtonsX(HorizontalDirection.left);
            }
        }
    }

    private void MoveMenuButtonsX(HorizontalDirection _direction)
    {
        rec.offsetMin += new Vector2(speed, rec.offsetMin.y) * (sbyte)_direction;
        rec.offsetMax += new Vector2(speed, rec.offsetMax.y) * (sbyte)_direction;
    }

    public void ButtonPositionReset()
    {
        rec.offsetMax = DefaultOffsetMax;
        rec.offsetMin = DefaultOffsetMin;
    }
}
