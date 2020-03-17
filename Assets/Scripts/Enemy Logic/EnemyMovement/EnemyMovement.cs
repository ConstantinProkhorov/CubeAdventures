using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int RotationSpeed = 1;
    protected float FallingSpeed;
    public GameLevelSceneController thisSceneController;
    protected void Start()
    {
        FallingSpeed = ActiveLevelData.FallingSpeed;
    }
    protected virtual void Movement()
    {     
        transform.Translate(0, FallingSpeed * Time.deltaTime, 0, Space.World);
    }
    protected virtual void Rotation()
    {
        transform.Rotate(0, -RotationSpeed, -RotationSpeed);
    }
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
        thisSceneController.DecrementEnemyCounter(gameObject);
    }
    public void StopMovement() => FallingSpeed = 0.0f;
}
