using UnityEngine;
using GameWork.Unity.Directions;

public class ButtonsSlideY : MonoBehaviour
{
    [SerializeField] private RectTransform rec = null;
    private Vector2 DefaultOffsetMin, DefaultOffsetMax;
    public float speed;
    public float checkPosON;
    public float checkPosDown = -150f;

	void Start()
    {
        DefaultOffsetMin = new Vector2(rec.offsetMin.x, rec.offsetMin.y);
        DefaultOffsetMax = new Vector2(rec.offsetMax.x, rec.offsetMax.y);
    }

    void Update()
    {
        if (PauseButton.PauseClick == true )
        {
            if (rec.offsetMin.y < checkPosON)
            {
                MoveMenuButtonsY(VerticalDirection.up);
            }

        }
        else if (PauseButton.PauseClick == false)
        {
            if (rec.offsetMin.y > checkPosDown)
            {
                MoveMenuButtonsY(VerticalDirection.down);
            }
        }
    }

    private void MoveMenuButtonsY(VerticalDirection _direction)
    {
        rec.offsetMin += new Vector2(rec.offsetMin.x, speed) * (sbyte)_direction;
        rec.offsetMax += new Vector2(rec.offsetMax.x, speed) * (sbyte)_direction;
    }

    public void ButtonPositionReset()
    {
        rec.offsetMax = DefaultOffsetMax;
        rec.offsetMin = DefaultOffsetMin;
    }
}
