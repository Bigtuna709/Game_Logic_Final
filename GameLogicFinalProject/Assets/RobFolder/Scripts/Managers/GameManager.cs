using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Analytics;

public enum GameState
{
    Tutorial,
    Area1,
    Area2,
    Area3
}
public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    public PlayerController player;

    public AnalyticsController analyticsCtrler;

    public List<PickUpController> allPickUpTypes = new List<PickUpController>();
    public List<CheckPointController> allCheckPoints = new List<CheckPointController>();

    public Transform playerRespawnPoint;

    public Transform tutorialSpawnPoint;
    public Transform areaOneSpawnPoint;
    public Transform areaTwoSpawnPoint;
    public Transform areaThreeSpawnPoint;

    public Light playerLight;
    public float lightLoweringAmount;
    public float healthLoweringAmount;
    public float totalHealth;
    public int maxPlayerLightRange;
    public int maxPlayerHealth;
    public int totalLives = 3;

    public GameObject gameOverCanvas;
    public GameObject endGameCanvas;
    public GameObject hud;
    public Slider healthBarSlider;
    public Slider lightLevelSlider;
    public Animator healthbarAnimator;

    public Text livesTextField;

    private void Start()
    {
        analyticsCtrler = FindObjectOfType<AnalyticsController>();
        maxPlayerHealth += IAPTemp.Instance.newMaxHealth;
        if(maxPlayerHealth > 200)
        {
            maxPlayerHealth = 200;
        }
        totalHealth = maxPlayerHealth;
        playerLight.range = maxPlayerLightRange;
        playerLight.intensity = IAPTemp.Instance.newMaxLight;
        if(playerLight.intensity == 0)
        {
            playerLight.intensity = 0.6f;
        }
        player = FindObjectOfType<PlayerController>();
        if (tutorialSpawnPoint != null)
        {
            playerRespawnPoint = tutorialSpawnPoint;
            gameState = GameState.Tutorial;
        }
        else
        {
            playerRespawnPoint = areaOneSpawnPoint;
            gameState = GameState.Area1;
        }

        if(hud != null)
        {
            hud.SetActive(true);
        }

        livesTextField.text = "Lives: " + totalLives.ToString();
        AudioManager.Instance.PlayClip("LabAmb");
        AudioManager.Instance.backGroundMusic.volume = 0.05f;
    }
    private void FixedUpdate()
    {
        // Lowers the player's light range over time
        if (playerLight.range > 5.5f)
        {
            StartCoroutine(LowerLightOverTime());
        }
        else
        {
            StartCoroutine(LowerHealthOverTime());
            AudioManager.Instance.PlayClip("MouseHurt");
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
        healthbarAnimator.SetBool("isShaking", false);
    }
    // Lowers the player's health over time and checks for game over when player has 0 health
    public IEnumerator LowerHealthOverTime()
    {
        yield return new WaitForSeconds(1f);
        totalHealth -= healthLoweringAmount * Time.deltaTime;
        healthBarSlider.value = totalHealth;
        if(healthbarAnimator.GetBool("isShaking") == false)
        {
            healthbarAnimator.SetBool("isShaking", true);
        }
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
        healthbarAnimator.SetTrigger("isDamaged");
        for (int i = 0; i < damage; i++)
        {
            yield return new WaitForSeconds(0.05f);
            totalHealth--;
            healthBarSlider.value = totalHealth;
            IsPlayerDead();
        }
        AudioManager.Instance.PlayClip("MouseHurt");
        //healthbarAnimator.SetBool("isShaking", false);
    }

    public void RespawnPlayer()
    {
        if(hud != null)
        {
            hud.SetActive(true);
        }
        playerLight.range = maxPlayerLightRange;
        player.transform.position = playerRespawnPoint.position;
        totalHealth = maxPlayerHealth;
        healthBarSlider.value = totalHealth;
        player.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void IsPlayerDead()
    {
        if (totalHealth <= 0)
        {
            totalLives--;
            livesTextField.text = "Lives: " + totalLives.ToString();
            //when player dies will record the # of times this method is called from the AnalyticsController. Which will count as the everytime the player dies.
            analyticsCtrler.recordNumberOfDeathsEvent();
            StopAllCoroutines();
            if (totalLives >= 1)
            {
                player.gameObject.SetActive(false);
                RespawnPlayer();
                totalHealth = maxPlayerHealth;
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
            //when player beats the game, call this Method from AnalyticsController to record the times level was beaten.
            analyticsCtrler.recordCompletedLevel();
            hud.SetActive(false);
            endGameCanvas.SetActive(true);
            Time.timeScale = 0.4f;
            Debug.Log("<color=blue>You escaped the maze!</color>");
        }
        else
        {
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("<color=red>Game Over</color>");
        }
    }

    public void OnExtralifeGained()
    {
        if(gameState != GameState.Tutorial)
        {
            gameState = GameState.Area1;
            playerRespawnPoint = areaOneSpawnPoint;
            RespawnPlayer();
            totalHealth = maxPlayerHealth;
        }
        else
        {
            playerRespawnPoint = tutorialSpawnPoint;
            RespawnPlayer();
            totalHealth = maxPlayerHealth;
        }
    }


}
