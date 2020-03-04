using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{ // Класс хранящий данные игрока после загрузки в едином месте и предоставляющий к ним доступ // функции загрузки сейвов должны быть отсюда убраны.
    public static PlayerData CurrentSessionPlayerData { get; set; }
    //==================================== 
    //TODO: разгрести радиоактивный каолоотствойник ниже
    // Этот кошмар из кода ниже остаток первых заходов. Приводится в порядок, оставлено, чтобы не ломать нынешний код. Вокруг старых статических переменных
    // создана оболочка из свойств. После разгребания надо подумать, хорошо ли вообще получать доступ к данным через статические переменные или есть способ лучше.
    // Блин, а если я удалю эти свойства, то отслеживать обращения к данным в этом классе станет очень сложно. Хм. 
    [Obsolete("Access this data throuh CurrentSessionPlayerData.* instead")]
    public static int Score { get => CurrentSessionPlayerData.TotalScore; set => CurrentSessionPlayerData.TotalScore = value; }
    [Obsolete("Access this data throuh CurrentSessionPlayerData.* instead")]
    public static int Diamonds { get => CurrentSessionPlayerData.Diamonds; set => CurrentSessionPlayerData.Diamonds = value; }
    [Obsolete("Access this data throuh CurrentSessionPlayerData.* instead")]
    public static string LastForm { get => CurrentSessionPlayerData.lastForm; set => CurrentSessionPlayerData.lastForm = value; }
    [Obsolete("Access this data throuh CurrentSessionPlayerData.* instead")]
    public static string LastLevel { get => CurrentSessionPlayerData.lastLevelPlayed; set => CurrentSessionPlayerData.lastLevelPlayed = value; }
    //конец ада под разгребание
    //====================================  
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
