using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickUpType
{
    Small,
    Big,
    Cheese
}
public class PickUpController : MonoBehaviour
{
    public PickUpType pickUpType;

    public GameManager gameMgr;
    public MeshRenderer meshRend;
    public int lightValue;
    public int healthValue;
    public bool isPickedUp;
    private void Start()
    {
        gameMgr = FindObjectOfType<GameManager>();
        meshRend = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            StartCoroutine(gameMgr.RewardPlayer(this));
            meshRend.enabled = false;
            isPickedUp = true;
        }
    }
}
