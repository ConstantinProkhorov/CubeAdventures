using UnityEngine;
using UnityEngine.UI;

public class PointPopUpTextUpdater : MonoBehaviour
{
    [SerializeField] private Text PointPopUpText;
    public void Start()
    {
        PointPopUpText.text = $"+{ActiveLevelData.ScorePerCoin}";
    }
}
