using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Advertisements : MonoBehaviour, IUnityAdsListener
{
    //GameID found in Unity Dashboard
    string gameID = "4073392";
    //Test mode to be set to true.
    bool testMode = true;

    //Name of the PlacementId for the reward video
    public string placementIdRewardVideo = "AOTDReward1";
    

    void Start()
    {
        Advertisement.AddListener(this);
        //Searches GameID & TestMode and calls them
        Advertisement.Initialize(gameID, testMode);

    }
    /// <summary>
    /// When Ad is ready play PlacementIdRewardVideo
    /// </summary>
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
        //if successfully completed, +1 life and update the text field for total lives.
        if(showResult == ShowResult.Finished)
        {
            Debug.Log("You have successfully gained a single life.");
            GameManager.Instance.totalLives++;
            GameManager.Instance.livesTextField.text = "Lives: " + GameManager.Instance.totalLives.ToString();
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
