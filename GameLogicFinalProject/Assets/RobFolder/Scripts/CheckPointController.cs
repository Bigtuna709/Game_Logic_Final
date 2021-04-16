using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPointController : MonoBehaviour
{
    public GameState gameState;

    public Animator areaOneDoorAnimator;
    public Animator areaTwoDoorAnimator;

    public GameObject checkPointCanvas1;
    public GameObject checkPointCanvas2;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Checks the gamestate of the checkpoint to the current gamestate
            // if its different it will change the gamestate to the checkpoint

            var state = GameManager.Instance.allCheckPoints.FirstOrDefault(x => x.gameState == gameState);
            if(state != null && state.gameState != GameState.Area3)
            {
                //Turns on the checkpoints canavas
                StartCoroutine(TurnOffCheckPointCanvasAfterTime(checkPointCanvas1));
                ChangeGameState(state);
                areaOneDoorAnimator.SetBool("isClosed", true);

                // Implement Area 2 pickups
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaTwoRatTrapLocations, ObjectPoolManager.Instance.allRatTrapsCreated);
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaTwoCheeseLocations, ObjectPoolManager.Instance.allCheeseCreated);
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaTwoBatteryLocations, ObjectPoolManager.Instance.allLargeBatteriesCreated);
                GameManager.Instance.playerRespawnPoint = GameManager.Instance.areaTwoSpawnPoint;
            }
            else
            {
                //Turns on the checkpoints canavas
                StartCoroutine(TurnOffCheckPointCanvasAfterTime(checkPointCanvas2));
                ChangeGameState(state);
                areaTwoDoorAnimator.SetBool("isClosed", true);

                // Implement Area 3 pickups
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaThreeBatteryLocations, ObjectPoolManager.Instance.allLargeBatteriesCreated);
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaThreeCheeseLocations, ObjectPoolManager.Instance.allCheeseCreated);
                PickUpsManager.Instance.PopulateNewAreaPickUps(PickUpsManager.Instance.areaThreeRatTrapLocations, ObjectPoolManager.Instance.allRatTrapsCreated);
                GameManager.Instance.playerRespawnPoint = GameManager.Instance.areaThreeSpawnPoint;
            }
        }

    }

    private void ChangeGameState(CheckPointController state)
    {
        // Removes all the pick ups from the previous area
        GameManager.Instance.gameState = state.gameState;
        Debug.Log("<color=cyan>You reached " + state.gameState + " checkpoint!</color>");
        PickUpsManager.Instance.RemovePreviousAreaPickUps(ObjectPoolManager.Instance.allCheeseCreated);
        PickUpsManager.Instance.RemovePreviousAreaPickUps(ObjectPoolManager.Instance.allRatTrapsCreated);
        PickUpsManager.Instance.RemovePreviousAreaPickUps(ObjectPoolManager.Instance.allSmallBatteriesCreated);
        PickUpsManager.Instance.RemovePreviousAreaPickUps(ObjectPoolManager.Instance.allLargeBatteriesCreated);
        GameManager.Instance.totalLives++;
        GameManager.Instance.livesTextField.text = GameManager.Instance.totalLives.ToString();
    }

    IEnumerator TurnOffCheckPointCanvasAfterTime(GameObject canvas)
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(3f);
        canvas.SetActive(false);
    }

}
