using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Screen borders range from -3.5 to 5.5")]
    private float SplitPosition;
    [SerializeField]
    private int SpawnNumber = 3;
    public GameObject ChildFigure;
    private LevelSceneController thisSceneController;
    private Transform ThisTransform;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        thisSceneController = ScriptHolder.GetComponent<LevelSceneController>();
        SplitPosition = Random.Range(-2f, 2f);
        ThisTransform = gameObject.transform;
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            for (int i = 0; i < SpawnNumber; i++)
            {
                Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
            thisSceneController.IncrementEnemyCounter((sbyte)SpawnNumber);
        }
    }
}
