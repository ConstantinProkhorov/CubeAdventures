using UnityEngine;
public class SceneController : BaseController
{ // Класс хранящий данные игрока после загрузки в едином месте и предоставляющий к ним доступ // функции загрузки сейвов должны быть отсюда убраны.
    private PlayerData playerData;

    public static int score;
    public static int currentLevelScore;
    public static int diamonds;
    public static string lastForm;
    public static string LastLevel;
    public static float r,g,b; // TODO: убрать, заменить на доступ через PlayerCurrentColor
    public static Color PlayerCurrentColor // cвойство с текущим цветом игрока
    {
        get { return new Color(r, g, b); }
        set { r = value.r; g = value.g; b = value.b; }
    }
    // словари для хранения данных для сущностей которые могут быть открыты/закрыты (уровни, цвета)
    public static LevelOpenCloseDictionary LevelStateDictionary { get; private set; }
    public static СolorOpenCloseDictionary ColorStateDictionary { get; private set; }
    // словари для хранения цен разблокировки

    public static LevelOpenPriceDictionary LevelPriceDictionary { get; private set; }
    public static ColorOpenPriceDictionary ColorPriceDictionary { get; private set; }
    public static int ScoreGainedOnLevel { get; set; }

    public void PlayerDataReset() // временный метод для отладки игры
    {
        LoadBlanckSaveFile();
    }
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

    //void OnApplicationPause()
    //{
    //    SaveFileManager.Save(new PlayerData(score, diamonds, form));
    //}
    void OnApplicationQuit() // сохранение только при выходе и при загрузке новой сцены в BaseController, в остальных случаях происходит точечное переписывание переменных этого класса
    {
        SaveFileManager.Save(new PlayerData(score, diamonds, lastForm, r, g, b, LastLevel, LevelOpenCloseDictionary.GetAllStates(), СolorOpenCloseDictionary.GetAllStates()));
    }

    private void LoadSaveFile() //TODO: эти методы тут не нужны.
    {
        playerData = SaveFileManager.Load();
        score = playerData.totalScore;
        lastForm = playerData.lastForm;
        diamonds = playerData.diamonds;
        r = playerData.r;
        g = playerData.g;
        b = playerData.b;
        LastLevel = playerData.lastLevelPlayed;
        LevelStateDictionary.SetAllStates(playerData.levelOpenCloseDictionary);
        ColorStateDictionary.SetAllStates(playerData.colorOpenCloseDictionary);
    }
    private void LoadBlanckSaveFile()
    {
        playerData = new PlayerData();
        score = playerData.totalScore;
        lastForm = playerData.lastForm;
        diamonds = playerData.diamonds;
        r = playerData.r;
        g = playerData.g;
        b = playerData.b;
        LastLevel = playerData.lastLevelPlayed;
        LevelStateDictionary.SetAllStates(playerData.levelOpenCloseDictionary);
        ColorStateDictionary.SetAllStates(playerData.colorOpenCloseDictionary);
    }
}
