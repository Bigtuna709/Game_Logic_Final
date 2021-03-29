using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPlayerLightPool;
    public PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    public void RewardPlayerWithLight(int lightValue)
    {
        
    }
}
