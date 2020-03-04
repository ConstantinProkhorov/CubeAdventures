using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{ // Класс хранящий данные игрока после загрузки в едином месте и предоставляющий к ним доступ 
    public static PlayerData CurrentSessionPlayerData { get; set; }
    // Доступ к членам PlayerData через оболочку свойств. Сделал так, чтобы было удобнее отслеживать доступ к данным. Не могу сказать, хорошее ли это 
    // решение, но буду смотреть на результат.
    public static int TotalWavesCleared { get => CurrentSessionPlayerData.TotalWavesCleared; set => CurrentSessionPlayerData.TotalWavesCleared = value; }
    public static int Score { get => CurrentSessionPlayerData.TotalScore; set => CurrentSessionPlayerData.TotalScore = value; }
    public static int Diamonds { get => CurrentSessionPlayerData.Diamonds; set => CurrentSessionPlayerData.Diamonds = value; }
    public static int Dynamite { get => CurrentSessionPlayerData.Dynamite; set => CurrentSessionPlayerData.Dynamite = value < 0 ? 0 : value; }
    public static string LastForm { get => CurrentSessionPlayerData.LastForm; set => CurrentSessionPlayerData.LastForm = value; }
    public static string LastLevel { get => CurrentSessionPlayerData.lastLevelPlayed; set => CurrentSessionPlayerData.lastLevelPlayed = value; }
    public static Color PlayerCurrentColor
    {
        get { return new Color(CurrentSessionPlayerData.r, CurrentSessionPlayerData.g, CurrentSessionPlayerData.b); }
        set { CurrentSessionPlayerData.r = value.r; CurrentSessionPlayerData.g = value.g; CurrentSessionPlayerData.b = value.b; }
    }
    // словари для хранения данных для сущностей которые могут быть открыты/закрыты (уровни, цвета)
    public static LevelOpenCloseDictionary LevelStateDictionary { get; private set; }
    public static СolorOpenCloseDictionary ColorStateDictionary { get; private set; }
    // словари для хранения цен разблокировки
    public static LevelOpenPriceDictionary LevelPriceDictionary { get; private set; }
    public static ColorOpenPriceDictionary ColorPriceDictionary { get; private set; }
    public static int ScoreGainedOnLevel { get; set; }
    // временный метод для отладки игры
    public void PlayerDataReset() => LoadBlanckSaveFile();
    void Start()
    {
        LevelStateDictionary = new LevelOpenCloseDictionary();
        LevelPriceDictionary = new LevelOpenPriceDictionary();
        ColorStateDictionary = new СolorOpenCloseDictionary();
        ColorPriceDictionary = new ColorOpenPriceDictionary();
        ScreenBorders.CalculateScreenBorders();
        try
        {
            LoadSaveFile();
        }
        catch 
        {
            LoadBlanckSaveFile();
        }
        LoadMenuScene();
    }
    // сохранение только при выходе и при загрузке новой сцены в BaseController, в остальных случаях происходит точечное переписывание переменных этого класса
    void OnApplicationQuit() => SaveFileManager.Save(new PlayerData(CurrentSessionPlayerData));
    private void LoadSaveFile() => CurrentSessionPlayerData = SaveFileManager.Load();
    private void LoadBlanckSaveFile() => CurrentSessionPlayerData = new PlayerData();
    private void LoadMenuScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
            SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
