using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected int RotationSpeed = 1;
    private (float min, float max) DestroyPosY;
    private (float min, float max) DestroyPosX;
    protected float FallingSpeed;
    public GameLevelSceneController thisSceneController;
    protected void Start()
    {
        FallingSpeed = ActiveLevelData.FallingSpeed;
        DestroyPosY = (ScreenBorders.Buttom + ScreenBorders.Buttom / 2, ScreenBorders.Top + ScreenBorders.Top / 2);
        DestroyPosX = (ScreenBorders.Left + ScreenBorders.Left / 2, ScreenBorders.Right + ScreenBorders.Right / 2);
    }
    protected virtual void Movement()
    {     
        transform.Translate(0, FallingSpeed * Time.deltaTime, 0, Space.World);
    }
    protected virtual void Rotation()
    {
        transform.Rotate(0, -RotationSpeed, -RotationSpeed);
    }
    protected void Destroy() // TODO: ок, а есть ли еще более оптимальный способ?
    {
        if (transform.localPosition.y < DestroyPosY.min || transform.localPosition.y > DestroyPosY.max)
        {
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter(gameObject);
        }
        if (transform.localPosition.x > DestroyPosX.max || transform.localPosition.x < DestroyPosX.min)
        {
            Destroy(gameObject);
            thisSceneController.DecrementEnemyCounter(gameObject);
        }
    }
    public void StopMovement() => FallingSpeed = 0.0f;
}
