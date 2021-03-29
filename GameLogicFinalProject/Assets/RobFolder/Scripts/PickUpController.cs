using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameManager gameMgr;
    public int lightValue;
    private void Start()
    {
        gameMgr = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            gameMgr.RewardPlayerWithLight(lightValue);
        }
    }
}
