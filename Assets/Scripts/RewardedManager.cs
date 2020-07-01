using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class RewardedManager : MonoBehaviour, IRewardedVideoAdListener
{
    string lastLevelName = SceneController.LastLevel;
    public LoadingBlurTransparencyChange loadingBlurTransparencyChange;
    [SerializeField] private Button Button = null;
    void Start ()
    {
		Appodeal.setRewardedVideoCallbacks(this);
	}
    void Update()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Button.interactable = true;
        }
        else
        {
            Button.interactable = false;
        }
    }

    public void onRewardedVideoClosed(bool finished)
	{
		SceneLoadManager.SceneLoad(lastLevelName);
        loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked;
    }

    public void onRewardedVideoLoaded(bool isPrecache) {  } //Called when rewarded video was loaded (precache flag shows if the loaded ad is precache).
    public void onRewardedVideoFailedToLoad() { loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked; } // Called when rewarded video failed to load
    public void onRewardedVideoShowFailed() { loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked; } // Called when rewarded video was loaded, but cannot be shown (internal network errors, placement settings, or incorrect creative)
    public void onRewardedVideoShown() { SceneLoadManager.SceneLoad(lastLevelName); loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked; } // Called when rewarded video is shown
    public void onRewardedVideoClicked() { } // Called when reward video is clicked
    public void onRewardedVideoFinished(double amount, string name) { SceneLoadManager.SceneLoad(lastLevelName); loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked; } // Called when rewarded video is viewed until the end
    public void onRewardedVideoExpired() { loadingBlurTransparencyChange.ButtonClicked = !loadingBlurTransparencyChange.ButtonClicked; } //Called when rewarded video is expired and can not be shown

    public void ShowRewarded()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }
}
