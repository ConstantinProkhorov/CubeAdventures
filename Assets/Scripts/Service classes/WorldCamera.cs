using UnityEngine;

public class WorldCamera : MonoBehaviour // класс для получения прямой ссылки на главную камеру.
{
    public static Camera _camera;
    void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }
}
