using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// Displays name of the wave.
/// Customizable with prefix and postfix.
/// </summary>
//С одной стороны этот класс можно использовать повсюду в рамках данного проекта. Это плюс.
//С другой он очень зависит сразу от нескольких классов. Это минус. 
public class WaveNameDisplay : MonoBehaviour
{
    [SerializeField] private Text DisplayText;
    [Tooltip("This string will be put before wave name.")]
    [SerializeField] private string Prefix;
    [Tooltip("This string will be put after wave name.")]
    [SerializeField] private string Postfix;
    void Start()
    {
        string LevelName;
        if (ListOfGameLevels.IsGameLevel(SceneLoadManager.ActiveSceneName))
        {
            LevelName = SceneLoadManager.ActiveSceneName;
        }
        else
        {
            LevelName = SceneController.LastLevel;
        }
        DisplayText.text =$"{Prefix}{GameData.LevelWaveName.Get(LevelName)}{Postfix}";
    }
}
