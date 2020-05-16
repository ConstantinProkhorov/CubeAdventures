using UnityEngine;
//класс, которого не должно быть. Но это косяк системы рассылки оповещений в игре. 
public class DecrementDynamite : MonoBehaviour
{
    public void Decrement() => SceneController.Dynamite--;
}
