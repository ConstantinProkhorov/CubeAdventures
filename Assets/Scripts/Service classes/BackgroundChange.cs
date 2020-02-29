using UnityEngine;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] private Material SceneSkybox;
    void Start()
    {
        WorldCamera._camera.GetComponent<Skybox>().material = SceneSkybox as Material;
    }
}
