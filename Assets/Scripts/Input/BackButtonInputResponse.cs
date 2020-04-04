using UnityEngine;

public class BackButtonInputResponse : InputResponse
{
    [SerializeField] private string SceneToLoad = "StartScene";
    public override void Execute() => SceneLoadManager.SceneLoad(SceneToLoad);
}
