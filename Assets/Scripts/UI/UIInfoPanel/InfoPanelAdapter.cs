using System;
using UnityEngine;
//Адаптер для новой инфопанели, сделанной на основе событий, а не на основе апдейта. 
//TODO: удалить после адаптации остальной архитектуры к новой инфопанели. 
public sealed class InfoPanelAdapter : MonoBehaviour, IInfoPanel
{
    #region IInfoPanel implementation
    [SerializeField] GameLevelSceneController gameLevelSceneController;
    public event Action<int> ScoreChanged;
    public event Action<int> DiamondsChanged;
    public event Action<int> DynamiteChanged;
    #endregion
    void FixedUpdate()
    {
        ScoreChanged?.Invoke(gameLevelSceneController.ScoreGainedOnLevel.Amount);
        DiamondsChanged?.Invoke(gameLevelSceneController.DiamondsGainedOnLevel.Amount);
        DynamiteChanged?.Invoke(SceneController.Dynamite);
    }
}
