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
        SceneManager.LoadScene("RobLevel");
        GameManager.Instance.gameState = GameState.Area1;
        GameManager.Instance.playerRespawnPoint = GameManager.Instance.areaOneSpawnPoint;
        //GameManager.Instance.player = playerController;
        //playerController.transform.position = GameManager.Instance.areaOneSpawnPoint.position;
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("TerryScene");
    }
}
