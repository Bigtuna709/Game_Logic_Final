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

    //Boolean to check if the game is paused
    public bool IsGamePaused = false;

    private void Start()
    {
        
    }

    //Pauses the game, through lowering the timescale, then opening canvases and checking the boolean if game is paused. With a singleton we call the button click sound.
    public void PauseGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(true);
            IsGamePaused = true;
    }

    //Resumes game through making timescale to 1, turns off pauseMenuCanvas, boolean is false. Plays button click sound from Audio Manager
    public void ResumeGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(false);
            IsGamePaused = false;

    }

    //Restarts game through reloading Terry's scene, unpauses the game through timescale 1. Plays a button click.
    public void RestartGame()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("TerryScene");
        Time.timeScale = 1f;
    }

    //Restarts game through reloading Robert's scene, unpauses the game through timescale 1. Plays a button click.
    public void RestartRobScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("RobLevel");
        Time.timeScale = 1f;
    }

    //Restarts game through reloading Jolanne's scene. Plays a button click.
    public void MainMenuScene()
    {
        AudioManager.Instance.PlayClip("ButtonClick");
        SceneManager.LoadScene("JolanScene");
    }
}
