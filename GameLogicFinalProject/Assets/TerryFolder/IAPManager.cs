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
        GameManager.Instance.playerLight.intensity = 1.2f;
       
    }

    public void OnMaxHealthIncreasePurchased()
    {
        GameManager.Instance.maxPlayerHealth = 200;
        
    }

    public void OnMaxSpeedIncreasedPurchased()
    {
        pController.playerMovementSpeed = 450;
    
    } 
}
