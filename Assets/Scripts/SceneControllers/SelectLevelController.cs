public class SelectLevelController : BaseController, IDictionarySupport
{
    public const byte buildIndex = 5;
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }
    public SelectLevelController()
    {
        UnlockDictionary = SceneController.LevelStateDictionary;
        PriceDictionary = SceneController.LevelPriceDictionary;
    }

    void Start()
    {
        thisSetActive(buildIndex);
    }
}
