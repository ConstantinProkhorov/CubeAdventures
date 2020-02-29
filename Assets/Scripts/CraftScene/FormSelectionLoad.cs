using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameWork.Unity.Directions;

public class FormSelectionLoad : MonoBehaviour
{
    public Button button;
    public Player_Assembler playerAssembler;

    private float[] positionArray;
    private GameObject[] FiguresArray;

    void Start()
    {
        //_Player_Assembler = gameObject.GetComponent<CraftSceneController>()._Player_Assembler;
        
        positionArray = new float[playerAssembler.FiguresQuantity];
        FiguresArray = new GameObject[playerAssembler.FiguresQuantity];

        float TotoalScreenLenght = ScreenBorders.Top + Mathf.Abs(ScreenBorders.Buttom);
        float PositionCoordinatesStep = TotoalScreenLenght / positionArray.Length;

        float UnasignedScreenLenght = ScreenBorders.Top + PositionCoordinatesStep;
        for (int i = 0; i < positionArray.Length; i++)
        {
            positionArray[i] = UnasignedScreenLenght -= PositionCoordinatesStep;
        }
    }

    public void createForms()
    {
        FormsSlide.direction = HorizontalDirection.left;
        for (int i = 0; i < playerAssembler.FiguresQuantity; i++)
        {
            FiguresArray[i] = playerAssembler.Player_Creator(new Vector3(ScreenBorders.HalfCamWidth * 2, positionArray[i], 2), i);
            FiguresArray[i].tag = "FormForSelection";
        }
    }

    public void DestroyForms()
    {
        Destroy(gameObject.GetComponent<SelectForm>()); 
        FormsSlide.direction = HorizontalDirection.right;
        StartCoroutine(DelayedFormsDestruction());
    }

    private IEnumerator DelayedFormsDestruction() // TODO: заменить на операцию с делегатом, принимающим из FormsSlide информацию об окончании движения. 
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < FiguresArray.Length; i++)
        {
            Destroy(FiguresArray[i]);
        }
    }
}

