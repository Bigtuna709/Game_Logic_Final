using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : Singleton<SceneLoader>
{
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void LoadScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("RobLevel");
        GameManager.Instance.gameState = GameState.Area1;
        GameManager.Instance.playerRespawnPoint = GameManager.Instance.areaOneSpawnPoint;
        //GameManager.Instance.player = playerController;
        //playerController.transform.position = GameManager.Instance.areaOneSpawnPoint.position;
    }

    public void PlayClipOnButtonClick()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
    }
    
    public void LoadStartScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("TerryScene");
    }

    // Leave the game.
    public void QuiGame()
    {
        Application.Quit();
    }
}
