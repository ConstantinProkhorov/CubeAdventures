using UnityEngine;

public class InputCapture : MonoBehaviour
{
    [TextArea(1, 2)]
    [SerializeField]
    private string ClassInfo = "Captures all non-touch player input.\nUses strategy pattern to assign specific response on input.";
    [Header("Input:")]
    [SerializeField] private KeyCode BackButton = KeyCode.Escape;
    [Header("InputResponse:")]
    [SerializeField] private InputResponse BackButtonResponse; 
    void Update()
    {
        if (Input.GetKeyDown(BackButton))
        {
            BackButtonResponse.Execute();
        }
    }
}
