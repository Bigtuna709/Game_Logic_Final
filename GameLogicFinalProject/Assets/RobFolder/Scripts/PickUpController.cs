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

    public MeshRenderer meshRend;
    public int lightValue;
    public int healthValue;
    public bool isPickedUp;

    public GameObject electricParticle;

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            StartCoroutine(GameManager.Instance.RewardPlayer(this));
            isPickedUp = true;
            meshRend.enabled = false;
            Instantiate(electricParticle, this.transform.position, this.transform.rotation);
        }
    }
}
