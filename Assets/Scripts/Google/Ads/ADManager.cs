using GoogleMobileAds.Api;
using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ADManager : MonoBehaviour
{
    public GameObject MainMenuHints, LevelsSecretLevels,hintsButton;
    public GPGSAchievements gPGSAchievements;


    private string APP_ID = "ca-app-pub-3940256099942544~3347511713";
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd rewardBasedVideoAd;

    AdRequest request = new AdRequest.Builder().AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();
    void Start()
    {
        MobileAds.Initialize(APP_ID);
    }
    //#################################################InterstitialVideo##################################################
    void RequestInterstitial()
    {
        string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitial_ID);

        // Called when an ad request has successfully loaded.
        this.interstitialAd.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitialAd.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitialAd.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitialAd.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitialAd.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        interstitialAd.LoadAd(request);
    }
    

    public void Display_InterstitialAD()
    {
        if (ActiveGame.adsEnabled == true)
        {
            RequestInterstitial();
            gameObject.SetActive(false);
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        gameObject.SetActive(true);
        this.interstitialAd.OnAdLoaded -= HandleOnAdLoaded;
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestInterstitial();
        this.interstitialAd.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        this.interstitialAd.OnAdOpening -= HandleOnAdOpened;
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        this.interstitialAd.OnAdClosed -= HandleOnAdClosed;
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        this.interstitialAd.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
    }
    //#################################################InterstitialVideo##################################################
    //#################################################REWARDEDVİDEO##################################################
    void RequestVideoAd()
    {
        string video_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardBasedVideoAd = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideoAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideoAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideoAd.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideoAd.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideoAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideoAd.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideoAd.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

        rewardBasedVideoAd.LoadAd(request, video_ID);
    }
    public void Display_Reward_Video()
    {
        RequestVideoAd();
        gameObject.SetActive(false);
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        if (rewardBasedVideoAd.IsLoaded())
        {
            rewardBasedVideoAd.Show();
            gameObject.SetActive(true);
        }
        rewardBasedVideoAd.OnAdLoaded -= HandleRewardBasedVideoLoaded;
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestVideoAd();
        rewardBasedVideoAd.OnAdFailedToLoad -= HandleRewardBasedVideoFailedToLoad;
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        rewardBasedVideoAd.OnAdOpening -= HandleRewardBasedVideoOpened;
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        rewardBasedVideoAd.OnAdStarted -= HandleRewardBasedVideoStarted;
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        rewardBasedVideoAd.OnAdClosed -= HandleRewardBasedVideoClosed;
        rewardBasedVideoAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        hintsButton.SetActive(true);
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        if (MainMenuHints.activeSelf==true)
        {
            IncreaseHints();
        }else if (LevelsSecretLevels.activeSelf == true)
        {
            IncreaseSecretLevelsAds();
        }
        IncreaseAchievementAds();
        rewardBasedVideoAd.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        hintsButton.SetActive(true);
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        rewardBasedVideoAd.OnAdLeavingApplication -= HandleRewardBasedVideoLeftApplication;
        hintsButton.SetActive(true);
    }
    //#################################################REWARDEDVİDEO##################################################
    private void IncreaseAchievementAds()
    {
        gPGSAchievements.UpdateIncrementalAds();
        SaveSystem.Save();
    }
    private void IncreaseHints()
    {
        if (ActiveGame.goldCoin<99999)
        {
            ActiveGame.goldCoin += 15;
            SaveSystem.Save();
        }
    }
    private void IncreaseSecretLevelsAds()
    {
        if (ActiveGame.secretLevelsAds<20)
        {
            ActiveGame.secretLevelsAds++;
            SaveSystem.Save();
        }
    }

    //################################################################################################################
}

