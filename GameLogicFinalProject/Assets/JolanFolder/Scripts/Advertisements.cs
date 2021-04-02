using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisements : MonoBehaviour, IUnityAdsListener
{
    string gameID = "4073392";
    bool testMode = true;

    public string placementIdRewardVideo = "AOTDReward1";
    public string placementIdBanner = "AOTDBanner1";

    void Start()
    {
        Advertisement.AddListener(this);

        Advertisement.Initialize(gameID, testMode);

    }

    public void ShowRewardVideo()
    {
        if(Advertisement.IsReady(placementIdRewardVideo))
        {
            Advertisement.Show(placementIdRewardVideo);
        }
    }
    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            Debug.Log("You have successfully gained a single life.");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Skipped the ad, unable to recieve reward");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Failed to watch");
        }
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

}
