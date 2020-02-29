using UnityEngine;
using GameWork.Unity.Directions;

public class TripleSplit : SplitStrategy
{
    public override void Split(GameObject childFigure, Transform splittingFigureTransform, LevelSceneController levelSceneController)
    {
        // нужно добавить установку угла падения для делящейся фигуры. 2f отлично работает. 
        DiagonalEnemyMovement ChildDiagonalMovement;
        VerticalEnemyMovement ChildVerticalMovement;
        SpawnPositionOffset = new Vector3(childFigure.transform.lossyScale.x, 0, 0);

        SpawningFigure = Instantiate(childFigure as GameObject, splittingFigureTransform.position, Quaternion.identity);
        ChildVerticalMovement = SpawningFigure.AddComponent<VerticalEnemyMovement>();
        ChildVerticalMovement.thisSceneController = levelSceneController;

        SpawningFigure = Instantiate(childFigure as GameObject, splittingFigureTransform.position - SpawnPositionOffset, Quaternion.identity);
        ChildDiagonalMovement = SpawningFigure.AddComponent<DiagonalEnemyMovement>();
        ChildDiagonalMovement.direction = HorizontalDirection.right;
        ChildDiagonalMovement.thisSceneController = levelSceneController;

        SpawningFigure = Instantiate(childFigure as GameObject, splittingFigureTransform.position + SpawnPositionOffset, Quaternion.identity);
        ChildDiagonalMovement = SpawningFigure.AddComponent<DiagonalEnemyMovement>();
        ChildDiagonalMovement.direction = HorizontalDirection.left;
        ChildDiagonalMovement.thisSceneController = levelSceneController;
    }
}
