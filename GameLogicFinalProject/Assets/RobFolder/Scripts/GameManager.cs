using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public List<PickUpController> allPickUps = new List<PickUpController>();

    public Light playerLight;
    public float lightLoweringAmount;
    public int totalHealth;
    public GameObject gameOverCanvas;

    private void Start()
    {
        totalHealth = 100;
    }
    private void FixedUpdate()
    {
        // Lowers the player's light range over time
        if (playerLight.range > 0)
        {
            StartCoroutine(LowerLightOverTime());
        }
    }
    // Lower the player's light range over time
    public IEnumerator LowerLightOverTime()
    {
        yield return new WaitForSeconds(1f);
        playerLight.range -= lightLoweringAmount * Time.deltaTime;

    }
    // fuction that will increase the player's light range or health on pick up
    public IEnumerator RewardPlayer(PickUpController pickUpCtrler)
    {
        // Checks the pick ups enum
        var pickUp = allPickUps.FirstOrDefault(x => x.pickUpType == pickUpCtrler.pickUpType);
        if (pickUp != null && pickUp.pickUpType == PickUpType.Cheese)
        {
            Debug.Log("<color=green>You picked up cheese!</color>");
            // Rewards health if cheese pickup
            for (int i = 0; i < pickUp.healthValue; i++)
            {
                yield return new WaitForSeconds(0.05f);
                totalHealth++;
            }
        }
        else
        {
            Debug.Log("<color=blue>You picked up a battery!</color>");
            // Rewards light range if a battery pick up
            for (int i = 0; i < pickUpCtrler.lightValue; i++)
            {
                yield return new WaitForSeconds(0.05f);
                playerLight.range++;
            }
        }
        
    }
    // End the game
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
    }
}
