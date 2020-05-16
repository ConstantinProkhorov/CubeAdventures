using UnityEngine;
using System.Collections;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int RotationSpeed = 1;
    [SerializeField] protected Rigidbody Rigidbody;
    protected float FallingSpeed;
    [SerializeField] public GameLevelSceneController thisSceneController;
    private const float StopMovementDelay = 2.0f;
    protected void Start()
    {
        FallingSpeed = ActiveLevelData.FallingSpeed;
        if (Rigidbody == null)
        {
            Rigidbody = gameObject.GetComponent<Rigidbody>();
        }
    }
    protected virtual void Movement()
    {
        Rigidbody.MovePosition(new Vector3(transform.position.x, transform.position.y + FallingSpeed * Time.deltaTime, transform.position.z));
    }
    protected virtual void Rotation()
    {
        transform.Rotate(0, -RotationSpeed, -RotationSpeed);
    }
    public void OnBecameInvisible() => Destroy(gameObject);
    /// <summary>
    /// Stops enemy figure movement and applies gravity to it.
    /// </summary>
    public virtual void StopMovement()
    {
        StartCoroutine(GravityForcedFall());
    }
    private IEnumerator GravityForcedFall()
    {
        FallingSpeed = 0.0f;
        yield return new WaitForSeconds(StopMovementDelay);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
