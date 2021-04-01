using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GameManager gameMgr;
    public MeshRenderer meshRend;
    public int lightValue;
    public bool isPickedUp;
    private void Start()
    {
        gameMgr = FindObjectOfType<GameManager>();
        meshRend = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isPickedUp)
            {
                StartCoroutine(gameMgr.RewardPlayerWithLight(lightValue));
                meshRend.enabled = false;
                isPickedUp = true;
            }
        }
    }
}
