using UnityEngine;
using UnityEngine.UI;

public class CraftCanvasSwap : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private Button selectForm;
    [SerializeField] private Button selectColor;
    [SerializeField] private Button saveFormSelection;
    [SerializeField] private Button saveColorSelection;

    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject formSelectionCanvas;
    [SerializeField] private GameObject colorSelectionCanvas;
    void Start()
    {
        selectForm.onClick.AddListener(FormSelectionMenu);
        selectColor.onClick.AddListener(ColorSelectionMenu);

        saveFormSelection.onClick.AddListener(SaveFormSelection);
        saveColorSelection.onClick.AddListener(SaveColorSelection);

        mainCanvas.SetActive(true);
        formSelectionCanvas.SetActive(false);
        colorSelectionCanvas.SetActive(false);
    }
    void FormSelectionMenu()
    {
        formSelectionCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }
    void ColorSelectionMenu()
    {
        colorSelectionCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }
    void SaveFormSelection()
    {
        mainCanvas.SetActive(true);
        formSelectionCanvas.SetActive(false);
    }
    void SaveColorSelection()
    {
        mainCanvas.SetActive(true);
        colorSelectionCanvas.SetActive(false);
    }
}
