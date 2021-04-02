using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //Reference to button
    public Button pauseMenuBTN;

    //Reference to PauseMenuCanvas
    public GameObject pauseMenuCanvas;

    public static bool IsGamePaused = false;

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
}
