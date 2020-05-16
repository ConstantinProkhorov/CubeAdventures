using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    [SerializeField] private Button ThisSwitch = null;
    [SerializeField] private Sprite OnSwitch = null;
    [SerializeField] private Sprite OffSwitch = null;
    //state of the switch, true == on, false == off
    private bool CurrentState = true;
    /// <summary>
    /// Changes the state of the switch to opposite.
    /// </summary>
    public void ToggleSwitch()
    {
        SetSwitchState(!CurrentState);
    }
    /// <summary>
    /// Sets the state of the switch.
    /// </summary>
    /// <param name="state">true == on, false == off</param>
    public void SetSwitchState(bool state)
    {
        CurrentState = state;
        if (state)
        {
            ThisSwitch.image.sprite = OnSwitch;
        }
        else
        {
            ThisSwitch.image.sprite = OffSwitch;
        }
    }
}
