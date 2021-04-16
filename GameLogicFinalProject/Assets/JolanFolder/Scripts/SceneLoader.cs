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

    //Loads Robert's Scene (Level 1)
    public void LoadScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("RobLevel");
        GameManager.Instance.gameState = GameState.Area1;
        GameManager.Instance.playerRespawnPoint = GameManager.Instance.areaOneSpawnPoint;
        //GameManager.Instance.player = playerController;
        //playerController.transform.position = GameManager.Instance.areaOneSpawnPoint.position;
    }

    //Calls the button click sound for buttons that can't get the reference for AudioManager
    public void PlayClipOnButtonClick()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
    }

    //Loads Terry's scene (tutorial scene)
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
