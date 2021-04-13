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
    public GameObject cheeseParticle;

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
            if(this.CompareTag("Cheese"))
            {
                Instantiate(cheeseParticle, this.transform.position, this.transform.rotation);
                AudioManager.Instance.PlayClip("CheeseMunch");
            }
            else
            {
                Instantiate(electricParticle, this.transform.position, this.transform.rotation);
                AudioManager.Instance.PlayClip("ElectricSound");
            }
        }
    }
}
