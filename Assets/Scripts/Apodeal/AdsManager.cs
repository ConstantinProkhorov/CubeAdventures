using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class AdsManager : MonoBehaviour
{
	private const string APP_KEY = "c775567ae7513437b8442bb003e4642eaaa168e60c4f43ce";
    [SerializeField] bool TestOnOff;

    public void Initialize(bool isTesting)
	{
		Appodeal.setTesting(isTesting);
		Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.setChildDirectedTreatment(true);
        Appodeal.initialize(APP_KEY, Appodeal.REWARDED_VIDEO /* | Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.BANNER | Appodeal.MREC*/, true);
	}
    private void Start()
    {
        Initialize(TestOnOff);
    }

    public void ShowBannerTop()
	{
		Appodeal.show(Appodeal.BANNER_TOP);
	}

    public void ShowNonSkippableVideo()
    {
        Appodeal.show(Appodeal.NON_SKIPPABLE_VIDEO);
    }

    public void ShowInterstitial()
    {
        Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void ShowRewarded()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }

    public void ShowMREC()
    {
        Appodeal.show(Appodeal.MREC);
    }

}
