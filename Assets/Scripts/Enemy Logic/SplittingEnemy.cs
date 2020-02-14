using GameWork.Unity.Directions;
using UnityEngine;

public class SplittingEnemy : MonoBehaviour
{
    private float SplitPosition;
    [SerializeField]
    private int SpawnNumber = 2;
    [SerializeField]private GameObject ChildFigure;
    private GameObject SpawningFigure;
    [SerializeField]private LevelSceneController thisSceneController;
    private Transform ThisTransform;
    private Vector3 SpawnPositionOffset;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        thisSceneController = ScriptHolder.GetComponent<LevelSceneController>();
        SplitPosition = Random.Range(-2f, 2f);
        ThisTransform = gameObject.transform;
        SpawnPositionOffset = new Vector3 (ChildFigure.transform.lossyScale.x / 2, 0, 0);
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            Split();
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
            thisSceneController.IncrementEnemyCounter((sbyte)SpawnNumber);
        }
    }

    private void Split() //TODO: я думаю, что тут можно уменьшить объем повторения кода и засунуть все в цикл используя анонимные методы, надо попробовать.
    {
        DiagonalEnemyMovement ChildFigureMovement;

        SpawningFigure = Instantiate(ChildFigure as GameObject, ThisTransform.position - SpawnPositionOffset, Quaternion.identity);
        ChildFigureMovement = SpawningFigure.AddComponent<DiagonalEnemyMovement>();     
        ChildFigureMovement.direction = HorizontalDirection.left;

        SpawningFigure = Instantiate(ChildFigure as GameObject, ThisTransform.position + SpawnPositionOffset, Quaternion.identity);
        ChildFigureMovement = SpawningFigure.AddComponent<DiagonalEnemyMovement>();
        ChildFigureMovement.direction = HorizontalDirection.right;

        Time.timeScale = 0.0f;
    }
    //private void TripleSplit() 
    //{
    // // добработать код
    //    HorizontalEnemyMovement ChildFigureMovement;
    //    SphereEnemyMovment sphereEnemyMovment;

    //    SpawningFigure = Instantiate(ChildFigure as GameObject, ThisTransform.position - SpawnPositionOffset, Quaternion.identity);
    //    ChildFigureMovement = SpawningFigure.AddComponent<HorizontalEnemyMovement>();
    //    ChildFigureMovement.direction = (float)HorizontalDirection.right;

    //    SpawningFigure = Instantiate(ChildFigure as GameObject, ThisTransform.position + SpawnPositionOffset, Quaternion.identity);
    //    ChildFigureMovement = SpawningFigure.AddComponent<HorizontalEnemyMovement>();
    //    ChildFigureMovement.direction = (float)HorizontalDirection.left;

    //    SpawningFigure = Instantiate(ChildFigure as GameObject, ThisTransform.position, Quaternion.identity);
    //    sphereEnemyMovment = SpawningFigure.AddComponent<SphereEnemyMovment>();

    //    Time.timeScale = 0.0f;
    //}
}

