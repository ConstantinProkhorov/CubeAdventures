using UnityEngine;
/// <summary>
/// Captures all non-touch player input.
/// Uses strategy pattern to assign specific response on input.
/// </summary>
public class InputCapture : MonoBehaviour
{
    [Header("Input:")]
    [SerializeField] private KeyCode BackButton = KeyCode.Escape;
    [Header("InputResponse:")]
    [SerializeField] private InputResponse BackButtonResponse = null; 
    void Update()
    {
        if (Input.GetKeyDown(BackButton))
        {
            BackButtonResponse.Execute();
        }
    }
}
