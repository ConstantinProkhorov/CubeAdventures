using UnityEngine;
public class CameraAttachment : MonoBehaviour
{
    private const int PlaneDistance = 10;
    [SerializeField] private Canvas _canvas = null;
    void Start()
    {
        _canvas.worldCamera = WorldCamera._camera;
        _canvas.planeDistance = PlaneDistance;
    }
}
