using UnityEngine;
using GameWork.Unity.Directions;

public enum SplitType
{
    TwoFiguresWithHorizontalMovement
    //ThreeFiguresWithDiagonalMovement
}
public class SplittingEnemy : MonoBehaviour
{
    private float SplitPosition;
    public SplitType SplitType;
    [SerializeField]
    private int SpawnNumber = 2;
    public GameObject ChildFigure;
    [SerializeField]private LevelSceneController thisSceneController;
    private Transform ThisTransform;
    void Start()
    {
        GameObject ScriptHolder = GameObject.Find("ScriptHolder");
        thisSceneController = ScriptHolder.GetComponent<LevelSceneController>();
        SplitType = thisSceneController.EnemyCreator.SplitType;
        SplitPosition = Random.Range(-2f, 2f);
        ThisTransform = gameObject.transform;
    }
    void Update()
    {
        if (transform.position.y <= SplitPosition)
        {
            Split(SplitType);
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter();
            thisSceneController.IncrementEnemyCounter((sbyte)SpawnNumber);
        }
    }

    private void Split(SplitType splitType)
    {
        HorizontalEnemyMovement ChildFigureMovement;
        switch (splitType)
        {
            case SplitType.TwoFiguresWithHorizontalMovement:
                Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
                ChildFigureMovement = ChildFigure.GetComponent<HorizontalEnemyMovement>();
                ChildFigureMovement.direction = (float)HorizontalDirection.left;
                ChildFigureMovement.thisSceneController = thisSceneController;

                Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
                ChildFigureMovement = ChildFigure.GetComponent<HorizontalEnemyMovement>();
                ChildFigureMovement.direction = (float)HorizontalDirection.right;
                ChildFigureMovement.thisSceneController = thisSceneController;

                break;
            //case SplitType.ThreeFiguresWithDiagonalMovement:
            //    Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
            //    ChildFigure.GetComponent<HorizontalEnemyMovement>().direction = (float)HorizontalDirection.left;
            //    Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
            //    ChildFigure.GetComponent<HorizontalEnemyMovement>().direction = (float)HorizontalDirection.right;
            //    Instantiate(ChildFigure, ThisTransform.position, Quaternion.identity);
            //    ChildFigure.GetComponent<HorizontalEnemyMovement>().direction = (float)HorizontalDirection.noDirection;
            //    break;
            //default:
            //    break;
        }
    }
}
