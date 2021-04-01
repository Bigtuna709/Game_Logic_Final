using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTriggerArea : MonoBehaviour
{
    GameManager gameMgr;

    private void Awake()
    {
        gameMgr = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameMgr.GameOver();
        }
    }
}
