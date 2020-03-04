using UnityEngine;
using UnityEngine.UI;
public class WaveNameDisplay : MonoBehaviour
{
    public Text LevelStartText;
    public LevelDataInput LevelDataInput;
    void Awake()
    {
        LevelStartText.text = $"{LevelDataInput.WaveName} incoming!!!";
    }
}
