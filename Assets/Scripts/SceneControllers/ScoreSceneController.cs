using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : BaseController
{
    [SerializeField] private int buildIndex = 4;
    public Text TotalWavesDisplay;
    //public Text HardestWaveDoneDisplay;
    public Text ScoreNumberDisplay;
    public Text DiamondsNumberDisplay;

    public GameObject PointsFigure;
    public GameObject DiamondsFigure;
    void Start()
    {
        thisSetActive(buildIndex); //установка данной сцены активной методом из наследуемого класса 
        ResultsDisplay();
        FiguresInstansiation();
    }
    private void ResultsDisplay()
    {
        ScoreNumberDisplay.text = SceneController.Score.ToString();
        DiamondsNumberDisplay.text = SceneController.Diamonds.ToString();
        TotalWavesDisplay.text = SceneController.CurrentSessionPlayerData.TotalWavesCleared.ToString();
    }   
    private void FiguresInstansiation()
    {
        // загрузка фигуры для очков
        Transform transform = ScoreNumberDisplay.GetComponent<Transform>();
        transform.position = transform.TransformPoint(transform.position);
        PointsFigure = Instantiate(PointsFigure, new Vector3(transform.position.x - transform.localScale.x, transform.position.y, 0), Quaternion.identity);
        // загрузка фигуры для брилиантов
        transform = DiamondsNumberDisplay.GetComponent<Transform>();
        transform.position = transform.TransformPoint(transform.position);
        DiamondsFigure = Instantiate(DiamondsFigure, new Vector3(transform.position.x - transform.localScale.x, transform.position.y, 0), Quaternion.Euler(255f, -1f, 0f));
    }
}
