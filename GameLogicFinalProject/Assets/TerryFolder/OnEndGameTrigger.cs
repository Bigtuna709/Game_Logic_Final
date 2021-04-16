using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEndGameTrigger : MonoBehaviour
{
    /// <summary>
    /// Trigger for end of tutorial pop up window
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
