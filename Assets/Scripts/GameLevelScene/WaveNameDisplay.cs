using UnityEngine;
using UnityEngine.UI;
public class WaveNameDisplay : MonoBehaviour
{
    public Text LevelStartText;
    public LevelDataInput LevelDataInput;
    void Start()
    {
        LevelStartText.text = $"{LevelDataInput.WaveName} incoming!!!";
    }
}
