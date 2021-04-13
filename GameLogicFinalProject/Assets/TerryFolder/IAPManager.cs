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

    public GameObject extraHealthText;
    public GameObject extraSpeedText;
    public GameObject extraLightText;

    public GameObject purchaseCompleteCVS;

    private void Awake()
    {
        pController = FindObjectOfType<PlayerController>();
    }

    public void OnMaxIntensityIncreasePurchased()
    {
        IAPTemp.Instance.newMaxLight = 1.2f;
        purchaseCompleteCVS.SetActive(true);
        extraLightText.SetActive(true);
        extraSpeedText.SetActive(false);
        extraHealthText.SetActive(false);
        lightIncreaseButton.interactable = false;
       
    }

    public void OnMaxHealthIncreasePurchased()
    {
        IAPTemp.Instance.newMaxHealth = 100;
        purchaseCompleteCVS.SetActive(true);
        extraHealthText.SetActive(true);
        extraSpeedText.SetActive(false);
        extraLightText.SetActive(false);
        extraHealthButton.interactable = false;
    }

    public void OnMaxSpeedIncreasedPurchased()
    {
        IAPTemp.Instance.newMaxSpeed = 250;
        purchaseCompleteCVS.SetActive(true);
        extraSpeedText.SetActive(true);
        extraLightText.SetActive(false);
        extraHealthText.SetActive(false);
        runSpeedButton.interactable = false;
    } 
}
