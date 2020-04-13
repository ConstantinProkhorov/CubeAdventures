using UnityEngine;
using UnityEngine.UI;

public class SelectColor : MonoBehaviour
{
    private Color CurrentColor, TargetColor;
    private MeshRenderer PlayerMeshRendere;
    public CraftSceneController InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;
    public BuyWindow buyWindow;
    private bool LerpOn = false;
    private const float speed = 1.0f;
    private float StartTime;
    private float t;
    public void Start()
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport; 
    }
    //TODO: это что здесь вообще делает? 
    //должно быть вынесено в отдельный класс
    void Update()
    {
        if (LerpOn && t < 1)
        {
            t = (Time.time - StartTime) * speed;
            PlayerMeshRendere.material.color = Color.Lerp(CurrentColor, TargetColor, t);
        }
        else if (t > 0)
        {
            LerpOn = false;
            t = 0;
        }
    }
    public void ChangeColor(GameObject thisButton)
    {
        if (thisSceneController.UnlockDictionary.GetState(thisButton.name))
        {
            PlayerMeshRendere = CraftSceneController.player.GetComponent<MeshRenderer>(); //как будто здесь GetComponent не убрать
            TargetColor = thisButton.GetComponent<Image>().color;
            SceneController.PlayerCurrentColor = TargetColor;
            CurrentColor = PlayerMeshRendere.material.color;
            LerpOn = true;
            StartTime = Time.time;
        }
        else
        {
            buyWindow.OpenBuyWindow(thisButton);
        }
    }
}
