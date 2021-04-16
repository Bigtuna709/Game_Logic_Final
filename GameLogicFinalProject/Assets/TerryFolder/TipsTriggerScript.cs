using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTriggerScript : MonoBehaviour
{
    public GameObject tipsCanvas;
    public GameObject batteryTips;
    public GameObject roombotTips;
    public GameObject mazeTips;

    //Turns on the battery tip at start
    private void Start()
    {
        tipsCanvas.SetActive(true);
        batteryTips.SetActive(true);
        Time.timeScale = 0;
    }

    //Turns on the roombot tips when trigger is hit
    public void OnRoombotTipTriggerHit()
    {
        batteryTips.SetActive(false);
        tipsCanvas.SetActive(true);
        roombotTips.SetActive(true);
        mazeTips.SetActive(false);
        Time.timeScale = 0;
    }

    //Turns on the maze tips when trigger is hit
    public void OnMazeTipTriggerHit()
    {
        batteryTips.SetActive(false);
        roombotTips.SetActive(false);
        tipsCanvas.SetActive(true);
        mazeTips.SetActive(true);
        Time.timeScale = 0;
    }

    //Closes the tips window
    public void BackButtonPressed()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        Time.timeScale = 1;
        tipsCanvas.SetActive(false);
    }
}
