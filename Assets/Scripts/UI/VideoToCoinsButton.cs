using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class VideoToCoinsButton : MonoBehaviour, IRewardedVideoAdListener
{
    [SerializeField] int RewardedCoinsAmmount = 100;
    void Start()
    {
        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void StartVideo()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);
        }
    }

    public void onRewardedVideoClosed(bool finished)
    {
        SceneController.Score += RewardedCoinsAmmount;
    }

    public void onRewardedVideoLoaded(bool isPrecache) { } //Called when rewarded video was loaded (precache flag shows if the loaded ad is precache).
    public void onRewardedVideoFailedToLoad() { } // Called when rewarded video failed to load
    public void onRewardedVideoShowFailed() { } // Called when rewarded video was loaded, but cannot be shown (internal network errors, placement settings, or incorrect creative)
    public void onRewardedVideoShown() {  } // Called when rewarded video is shown
    public void onRewardedVideoClicked() { } // Called when reward video is clicked
    public void onRewardedVideoFinished(double amount, string name) { } // Called when rewarded video is viewed until the end
    public void onRewardedVideoExpired() {  } //Called when rewarded video is expired and can not be shown

}
