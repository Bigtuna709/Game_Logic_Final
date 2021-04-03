using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public enum GameState
{
    Area1,
    Area2,
    Area3
}
public class GameManager : MonoBehaviour
{
    public GameState gameState;

    public List<PickUpController> allPickUps = new List<PickUpController>();
    public List<CheckPointController> allCheckPoints = new List<CheckPointController>();

    public Light playerLight;
    public float lightLoweringAmount;
    public float healthLoweringAmount;
    public float totalHealth;

    public GameObject gameOverCanvas;
    public Slider healthBarSlider;
    public Slider lightLevelSlider;

    private void Start()
    {
        totalHealth = 100;
        playerLight.range = 30;
        gameState = GameState.Area1;
    }
    private void FixedUpdate()
    {
        // Lowers the player's light range over time
        if (playerLight.range > 0)
        {
            StartCoroutine(LowerLightOverTime());
        }
        else
        {
            StartCoroutine(LowerHealthOverTime());
        }
    }
    // Lower the player's light range over time
    public IEnumerator LowerLightOverTime()
    {
        yield return new WaitForSeconds(1f);
        playerLight.range -= lightLoweringAmount * Time.deltaTime;
        lightLevelSlider.value = playerLight.range;

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
                if (totalHealth > 100)
                {
                    totalHealth = 100;
                }
                healthBarSlider.value = totalHealth;
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
                if(playerLight.range > 30)
                {
                    playerLight.range = 30;
                }
                lightLevelSlider.value = playerLight.range;
            }
        }
        
    }

    // Lowers the player's health over time and checks for game over when player has 0 health
    public IEnumerator LowerHealthOverTime()
    {
        yield return new WaitForSeconds(1f);
        totalHealth -= healthLoweringAmount * Time.deltaTime;
        healthBarSlider.value = totalHealth;
        if(totalHealth == 0)
        {
            totalHealth = 0;
            GameOver();
        }

    }
    // Function to damage the player
    public IEnumerator PlayerTakeDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            yield return new WaitForSeconds(0.05f);
            totalHealth--;
            healthBarSlider.value = totalHealth;
        }
    }

    // End the game
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Debug.Log("<color=red>Game Over</color>");
    }
}
