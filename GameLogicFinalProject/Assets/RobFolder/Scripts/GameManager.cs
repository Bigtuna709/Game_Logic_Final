using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPlayerLightPool;
    public Light playerLight;
  
    public void RewardPlayerWithLight(int lightValue)
    {
        playerLight.range += lightValue;
    }
}
