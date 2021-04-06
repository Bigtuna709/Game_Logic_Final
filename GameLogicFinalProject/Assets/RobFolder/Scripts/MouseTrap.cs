using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public int trapDamage;
    public bool isSprung;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        isSprung = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSprung)
            {
                // Checks if it is sprung and deals damage if its not
                animator.SetBool("isSprung", true);
                isSprung = true;
                StartCoroutine(GameManager.Instance.PlayerTakeDamage(trapDamage));
                Debug.Log("<color=red>You walked over a trap!</color>");
            }
        }
    }
}
