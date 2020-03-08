using UnityEngine;
using GameWork.Unity.Directions;

public class DoubleSplitHorizontalFlight : SplitStrategy
{
    //TODO: я думаю, что тут можно уменьшить объем повторения кода и засунуть все в цикл используя анонимные методы, надо попробовать.
    public override void Split(GameObject childFigure, Transform splittingFigureTransform, GameLevelSceneController levelSceneController)
    {
        HorizontalEnemyMovement ChildFigureMovement;
        SpawnPositionOffset = new Vector3(childFigure.transform.lossyScale.x / 2, 0, 0);        

        SpawningFigure = Instantiate(childFigure as GameObject, splittingFigureTransform.position - SpawnPositionOffset, Quaternion.identity);
        ChildFigureMovement = SpawningFigure.AddComponent<HorizontalEnemyMovement>();
        ChildFigureMovement.direction = HorizontalDirection.right;
        ChildFigureMovement.thisSceneController = levelSceneController;

        SpawningFigure = Instantiate(childFigure as GameObject, splittingFigureTransform.position + SpawnPositionOffset, Quaternion.identity);
        ChildFigureMovement = SpawningFigure.AddComponent<HorizontalEnemyMovement>();
        ChildFigureMovement.direction = HorizontalDirection.left;
        ChildFigureMovement.thisSceneController = levelSceneController;
    }
}
