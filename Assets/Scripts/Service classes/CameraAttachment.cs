using UnityEngine;
public class CameraAttachment : MonoBehaviour
{
    private const int PlaneDistance = 10;
#pragma warning disable 649
    [SerializeField] private Canvas _canvas;
    void Start()
    {
        _canvas.worldCamera = WorldCamera._camera;
        _canvas.planeDistance = PlaneDistance;
    }
}
