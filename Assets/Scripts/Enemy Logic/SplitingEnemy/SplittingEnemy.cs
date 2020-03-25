using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject ChildFigure;
    [SerializeField] private GameLevelSceneController thisSceneController;    
    private SplitStrategy SplitStrategy;

    private float SplitPosition;
    [SerializeField] private float MaxAllowedSplitPosition = 2.0f;
    [SerializeField] private float MinAllowedSplitPosition = -2.0f;
    void Start()
    {
        thisSceneController = gameObject.GetComponent<EnemyMovement>().thisSceneController;
        SplitPosition = Random.Range(MinAllowedSplitPosition, MaxAllowedSplitPosition);
        SplitStrategy = gameObject.GetComponent<SplitStrategy>();
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            SplitStrategy.Split(ChildFigure, gameObject.transform, thisSceneController);
            Destroy(gameObject);
        }
    }
}

