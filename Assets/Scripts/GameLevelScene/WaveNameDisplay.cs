using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveNameDisplay : MonoBehaviour
{
    [SerializeField] private Text LevelStartText;
    [Tooltip("This string will be put before wave name.")]
    [SerializeField] private string Prefix;
    [Tooltip("This string will be put after wave name.")]
    [SerializeField] private string Postfix;
    void Start()
    {
        string LevelName;
        if (SceneLoadManager.IsGameLevel())
        {
            LevelName = SceneManager.GetSceneByBuildIndex(SceneLoadManager.ActiveSceneIndex).name;
        }
        else
        {
            LevelName = SceneController.LastLevel;
        }
        LevelStartText.text =$"{Prefix}{GameData.LevelWaveName.Get(LevelName).ToUpper()}{Postfix}";
    }
}
