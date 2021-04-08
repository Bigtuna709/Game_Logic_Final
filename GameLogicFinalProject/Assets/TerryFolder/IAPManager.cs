using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour
{
    //Increase player max intensity
    //Increase player max health
    //Increase player speed

    PlayerController pController;

    private void Awake()
    {
        pController = FindObjectOfType<PlayerController>();
    }

    public void OnMaxIntensityIncreasePurchased()
    {
        IAPTemp.Instance.newMaxLight = 1.2f;
       
    }

    public void OnMaxHealthIncreasePurchased()
    {
        IAPTemp.Instance.newMaxHealth = 100;
        
    }

    public void OnMaxSpeedIncreasedPurchased()
    {
        IAPTemp.Instance.newMaxSpeed = 250;
    
    } 
}
