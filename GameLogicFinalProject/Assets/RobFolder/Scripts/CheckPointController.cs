using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPointController : MonoBehaviour
{
    public GameManager gameMgr;
    public GameState gameState;

    private void Awake()
    {
        gameMgr = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Checks the gamestate of the checkpoint to the current gamestate
            // if its different it will change the gamestate to the checkpoint

            var state = gameMgr.allCheckPoints.FirstOrDefault(x => x.gameState == gameState);
            if(state != null && state.gameState != gameMgr.gameState)
            {
                gameMgr.gameState = state.gameState;
                Debug.Log("<color=cyan>You reached " + state.gameState + " checkpoint!</color>");
            }
        }
    }
}
