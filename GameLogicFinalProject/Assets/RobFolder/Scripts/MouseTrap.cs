using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public GameManager gameMgr;

    public int trapDamage;
    public bool isSpronge;

    private void Awake()
    {
        gameMgr = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isSpronge)
            {
                isSpronge = true;
                gameMgr.PlayerTakeDamage(trapDamage);
                gameMgr.healthBarSlider.value = gameMgr.totalHealth;
            }
        }
    }
}
