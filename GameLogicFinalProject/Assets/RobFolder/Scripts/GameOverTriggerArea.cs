using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneLoader.Instance.LoadScene();
            GameManager.Instance.gameState = GameState.Area1;
        }
    }
}
