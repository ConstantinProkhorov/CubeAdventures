using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneController : BaseController
{
    [SerializeField] private byte buildIndex = 4;

    public Text scoreNumberDisplay;
    public Text diamondsNumberDisplay;

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
        scoreNumberDisplay.text = SceneController.score.ToString();
        diamondsNumberDisplay.text = SceneController.diamonds.ToString();
    }   

    private void FiguresInstansiation()
    {
        // загрузка фигуры для очков
        Transform transform = scoreNumberDisplay.GetComponent<Transform>();
        transform.position = transform.TransformPoint(transform.position);
        PointsFigure = Instantiate(PointsFigure, new Vector3(transform.position.x - transform.localScale.x, transform.position.y, 0), Quaternion.identity);
        // загрузка фигуры для брилиантов
        transform = diamondsNumberDisplay.GetComponent<Transform>();
        transform.position = transform.TransformPoint(transform.position);
        DiamondsFigure = Instantiate(DiamondsFigure, new Vector3(transform.position.x - transform.localScale.x, transform.position.y, 0), Quaternion.Euler(255f, -1f, 0f));
    }
}
