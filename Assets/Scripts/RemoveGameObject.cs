using UnityEngine;

public abstract class RemoveGameObject : MonoBehaviour
{
    /// <summary>
    /// Makes gameObject invisible for the player but still active. Exact logic of removal is implemented in subclasses.
    /// </summary>
    public abstract void Remove();
}
