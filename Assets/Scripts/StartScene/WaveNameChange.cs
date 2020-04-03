using UnityEngine;
using UnityEngine.UI;

public class WaveNameChange : MonoBehaviour
{
    [SerializeField] Text WaveName;
    void Start()
    {
        WaveName.text = $"{SceneController.CurrentWaveName}";
    }
}
