using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    private float SplitPosition;
    [SerializeField]
    private int SpawnNumber = 2;
    [SerializeField]private GameObject ChildFigure;
    [SerializeField]private LevelSceneController thisSceneController;    
    private SplitStrategy SplitStrategy;
    void Start()
    {
        thisSceneController = gameObject.GetComponent<EnemyMovement>().thisSceneController;
        SplitPosition = Random.Range(-2f, 2f);
        SplitStrategy = gameObject.GetComponent<SplitStrategy>();
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            SplitStrategy.Split(ChildFigure, gameObject.transform, thisSceneController);
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
            thisSceneController.IncrementEnemyCounter((sbyte)SpawnNumber);
        }
    }
}

