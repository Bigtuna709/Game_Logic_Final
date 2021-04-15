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
        
    }

    public void PauseGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(true);
            IsGamePaused = true;
    }

    public void ResumeGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(false);
            IsGamePaused = true;

    }

    public void RestartGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("TerryScene");
        Time.timeScale = 1f;
    }
    public void RestartRobScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("RobLevel");
        Time.timeScale = 1f;
    }

    public void MainMenuScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("JolanScene");
    }
}
