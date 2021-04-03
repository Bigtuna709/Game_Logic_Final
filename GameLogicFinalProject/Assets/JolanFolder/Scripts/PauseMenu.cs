using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Reference to button
    private Button pauseMenuBTN;

    //Reference to PauseMenuCanvas
    public GameObject pauseMenuCanvas;
    public Animator PopUpAnim;

    public static bool IsGamePaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TerryScene");
        Time.timeScale = 1f;
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("JolanScene");
    }
}
