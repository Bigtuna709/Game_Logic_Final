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
public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public PlayerController player;

    public List<PickUpController> allPickUpTypes = new List<PickUpController>();
    public List<CheckPointController> allCheckPoints = new List<CheckPointController>();

    public Transform playerRespawnPoint;

    public Transform areaOneSpawnPoint;
    public Transform areaTwoSpawnPoint;
    public Transform areaThreeSpawnPoint;

    public Light playerLight;
    public float lightLoweringAmount;
    public float healthLoweringAmount;
    public float totalHealth;
    public int maxPlayerLightRange;
    public int maxPlayerHealth;
    public int totalLives;

    public GameObject gameOverCanvas;
    public Slider healthBarSlider;
    public Slider lightLevelSlider;

    private void Start()
    {
        totalHealth = maxPlayerHealth;
        playerLight.range = maxPlayerLightRange;
        gameState = GameState.Area1;
        player = FindObjectOfType<PlayerController>();
        playerRespawnPoint = areaOneSpawnPoint;
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
        if(playerLight.range < 0)
        {
            playerLight.range = 0;
        }
        lightLevelSlider.value = playerLight.range;

    }
    // Lowers the player's health over time and checks for game over when player has 0 health
    public IEnumerator LowerHealthOverTime()
    {
        yield return new WaitForSeconds(1f);
        totalHealth -= healthLoweringAmount * Time.deltaTime;
        healthBarSlider.value = totalHealth;
        IsPlayerDead();

    }
    // fuction that will increase the player's light range or health on pick up
    public IEnumerator RewardPlayer(PickUpController pickUpCtrler)
    {
        // Checks the pick ups enum
        var pickUp = allPickUpTypes.FirstOrDefault(x => x.pickUpType == pickUpCtrler.pickUpType);
        if (pickUp != null && pickUp.pickUpType == PickUpType.Cheese)
        {
            Debug.Log("<color=green>You picked up cheese!</color>");
            // Rewards health if cheese pickup
            for (int i = 0; i < pickUp.healthValue; i++)
            {
                yield return new WaitForSeconds(0.05f);
                totalHealth++;
                if (totalHealth > maxPlayerHealth)
                {
                    totalHealth = maxPlayerHealth;
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
                if(playerLight.range > maxPlayerLightRange)
                {
                    playerLight.range = maxPlayerLightRange;
                }
                lightLevelSlider.value = playerLight.range;
            }
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
            IsPlayerDead();
        }
    }

    public void RespawnPlayer()
    {
        playerLight.range = maxPlayerLightRange;
        player.transform.position = playerRespawnPoint.position;
        totalHealth = maxPlayerHealth;
        player.gameObject.SetActive(true);
    }

    public void IsPlayerDead()
    {
        if (totalHealth < 0)
        {
            StopAllCoroutines();
            if (totalLives > 0)
            {
                player.gameObject.SetActive(false);
                totalLives--;
                RespawnPlayer();
            }
            else
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (totalHealth > 0)
        {
            Debug.Log("<color=blue>You escaped the maze!</color>");
        }
        else
        {
            gameOverCanvas.SetActive(true);
            Debug.Log("<color=red>Game Over</color>");
        }
    }
}
