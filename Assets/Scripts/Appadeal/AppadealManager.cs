using System;
using System.Collections;
using System.Collections.Generic;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using UnityEngine;

public class AppadealManager : MonoBehaviour, IRewardedVideoAdListener
{
    private const string APP_KEY = "db6fec3562b467247a3882be10c2efcf61578701a3509a61";

    [SerializeField] private bool testingMode;

    public static Action OnRewardedVideoFinishedAction;

    private void Start()
    {
        Initialized();

        LevelChanger.OnStartNewLvl += ShowInterAds;
    }

    public void ShowInterAds()
    {
        if (Appodeal.CanShow(AppodealAdType.Interstitial))
        {
            Appodeal.Show(AppodealAdType.Interstitial);
        }
    }
    
    
    private void Initialized()
    {
        Appodeal.SetTesting(testingMode);
        
        Appodeal.MuteVideosIfCallsMuted(true);
        
        Appodeal.Initialize(APP_KEY, AppodealAdType.Interstitial);
         
        Appodeal.SetRewardedVideoCallbacks(this);
    }

    public void OnRewardedVideoLoaded(bool isPrecache)
    {
        throw new System.NotImplementedException();
    }

    public void OnRewardedVideoFailedToLoad()
    {
        throw new System.NotImplementedException();
    }

    public void OnRewardedVideoShowFailed()
    {
        throw new System.NotImplementedException();
    }

    public void OnRewardedVideoShown()
    {
        throw new System.NotImplementedException();
    }

    public void OnRewardedVideoFinished(double amount, string currency)
    {
        OnRewardedVideoFinishedAction?.Invoke();
    }

    public void OnRewardedVideoClosed(bool finished)
    {
        OnRewardedVideoFinishedAction?.Invoke();
    }

    public void OnRewardedVideoExpired()
    {
        throw new System.NotImplementedException();
    }

    public void OnRewardedVideoClicked()
    {
        throw new System.NotImplementedException();
    }

    private void OnDestroy()
    {
        LevelChanger.OnStartNewLvl -= ShowInterAds;
    }
}
