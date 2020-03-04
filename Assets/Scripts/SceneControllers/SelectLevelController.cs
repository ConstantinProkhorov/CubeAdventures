using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevelController : MonoBehaviour, IDictionarySupport
{
    public IOpenCloseDictionary UnlockDictionary { get; set; }
    public IPriceDictionary PriceDictionary { get; set; }
    public SelectLevelController()
    {
        UnlockDictionary = SceneController.LevelStateDictionary;
        PriceDictionary = SceneController.LevelPriceDictionary;
    }
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(gameObject.scene.buildIndex));
    }
}
