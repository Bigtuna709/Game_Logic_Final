using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour
{
    //Increase player max intensity
    //Increase player max health
    //Increase player speed

    PlayerController pController;

    public Button lightIncreaseButton;
    public Button runSpeedButton;
    public Button extraHealthButton;

    private void Awake()
    {
        pController = FindObjectOfType<PlayerController>();
    }

    public void OnMaxIntensityIncreasePurchased()
    {
        IAPTemp.Instance.newMaxLight = 1.2f;
        lightIncreaseButton.interactable = false;
       
    }

    public void OnMaxHealthIncreasePurchased()
    {
        IAPTemp.Instance.newMaxHealth = 100;
        extraHealthButton.interactable = false;
    }

    public void OnMaxSpeedIncreasedPurchased()
    {
        IAPTemp.Instance.newMaxSpeed = 250;
        runSpeedButton.interactable = false;
    } 
}
