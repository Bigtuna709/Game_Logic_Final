using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTrap : MonoBehaviour
{
    public int trapDamage;
    public int trapResetTimer = 5;
    public bool isSprung;
    public Animator animator;
    public GameObject sparksParticle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isSprung)
            {
                // Checks if it is sprung and deals damage if its not
                AudioManager.Instance.PlayClip("MouseTrap");
                Instantiate(sparksParticle, this.transform.position, sparksParticle.transform.rotation);
                animator.SetBool("isSprung", true);
                isSprung = true;
                StartCoroutine(GameManager.Instance.PlayerTakeDamage(trapDamage));
                StartCoroutine(ResetTrap());
                Debug.Log("<color=red>You walked over a trap!</color>");
            }
        }
    }

    public IEnumerator ResetTrap()
    {
        // Resets the trap
        yield return new WaitForSeconds(trapResetTimer);
        isSprung = false;
    }
}
