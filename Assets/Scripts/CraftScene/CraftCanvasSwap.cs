using UnityEngine;
using UnityEngine.UI;

public class FormSelectionButton : MonoBehaviour
{
    public Button selectForm;
    public Button saveSelection;
#pragma warning disable 649
    GameObject mainCanvas;
#pragma warning disable 649
    GameObject formSelectionCanvas;
    void Start()
    {
        selectForm.onClick.AddListener(OnClick);
        saveSelection.onClick.AddListener(OnClick);
        formSelectionCanvas.SetActive(false);
        mainCanvas.SetActive(true);
    }

    void OnClick()
    {
        formSelectionCanvas.SetActive(true);
        mainCanvas.SetActive(false); 
    }
}
