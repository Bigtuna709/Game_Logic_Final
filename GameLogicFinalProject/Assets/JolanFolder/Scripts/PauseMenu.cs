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

    public bool IsGamePaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
       if(IsGamePaused != true)
        {
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(true);
            IsGamePaused = true;
        }
    }

    public void ResumeGame()
    {
        if (IsGamePaused != false)
        {
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(false);
            IsGamePaused = true;
        }

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
