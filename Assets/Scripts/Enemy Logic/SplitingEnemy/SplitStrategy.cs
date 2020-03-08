using UnityEngine;
// учитывая ограничения работы инспектора юнити я использую абстрактный класс вместо интерфейса, для реализации паттерна стратегия. Посмотрим на результат. 
public abstract class SplitStrategy : MonoBehaviour
{
    protected GameObject SpawningFigure;
    protected Vector3 SpawnPositionOffset;
    public abstract void Split(GameObject childFigure, Transform splittingFigureTransform, GameLevelSceneController levelSceneController);
}
