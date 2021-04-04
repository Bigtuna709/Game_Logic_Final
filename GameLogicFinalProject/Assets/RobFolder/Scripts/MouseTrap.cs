using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public int trapDamage;
    public bool isSprung;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isSprung)
            {
                // Checks if it is sprung and deals damage if its not
                isSprung = true;
                StartCoroutine(GameManager.Instance.PlayerTakeDamage(trapDamage));
                Debug.Log("<color=red>You walked over a trap!</color>");
            }
        }
    }
}
