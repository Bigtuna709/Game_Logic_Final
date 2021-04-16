using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerArea : MonoBehaviour
{
    /// <summary>
    /// End game trigger resets gamestate to Area1
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadScene();
            GameManager.Instance.gameState = GameState.Area1;
        }
    }
}
