using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public GameManager gameMgr;

    public int trapDamage;
    public bool isSprung;

    private void Awake()
    {
        gameMgr = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isSprung)
            {
                // Checks if it is sprung and deals damage if its not
                isSprung = true;
                StartCoroutine(gameMgr.PlayerTakeDamage(trapDamage));
                Debug.Log("<color=red>You walked over a trap!</color>");
            }
        }
    }
}
