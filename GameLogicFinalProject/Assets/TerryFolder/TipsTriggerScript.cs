using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsTriggerScript : MonoBehaviour
{
    public GameObject tipsCanvas;
    public GameObject batteryTips;
    public GameObject roombotTips;
    public GameObject mazeTips;

    private void Start()
    {
        tipsCanvas.SetActive(true);
        batteryTips.SetActive(true);
    }

    public void OnRoombotTipTriggerHit()
    {
        batteryTips.SetActive(false);
        tipsCanvas.SetActive(true);
        roombotTips.SetActive(true);
        mazeTips.SetActive(false);
    }

    public void OnMazeTipTriggerHit()
    {
        batteryTips.SetActive(false);
        roombotTips.SetActive(false);
        tipsCanvas.SetActive(true);
        mazeTips.SetActive(true);
    }

    public void BackButtonPressed()
    {
        tipsCanvas.SetActive(false);
    }
}
