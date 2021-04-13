using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerMovementSpeed;

    public Rigidbody rb;

    public PlayerButtons moveUpButton;
    public PlayerButtons moveDownButton;
    public PlayerButtons moveLeftButton;
    public PlayerButtons moveRightButton;

    public Animator animator;
    private Vector3 lastPosition;

    private void Start()
    {
        playerMovementSpeed += IAPTemp.Instance.newMaxSpeed;
        if(playerMovementSpeed > 450)
        {
            playerMovementSpeed = 450;
        }
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        //Checks if a UI movement button is pressed and moves the player if true
        Vector3 velocity = Vector3.zero;
        if (moveUpButton.IsPressed)
        {
            velocity.z -= playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
            AudioManager.Instance.PlayClip("Footsteps");
        }
        if (moveDownButton.IsPressed)
        {
            velocity.z += playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(-Vector3.forward);
            AudioManager.Instance.PlayClip("Footsteps");
        }
        if (moveLeftButton.IsPressed)
        {
            velocity.x += playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(-Vector3.right);
            AudioManager.Instance.PlayClip("Footsteps");
        }
        if (moveRightButton.IsPressed)
        {
            velocity.x -= playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(Vector3.right);
            AudioManager.Instance.PlayClip("Footsteps");
        }

        rb.velocity = velocity * Time.deltaTime;
        float speed = Vector3.Distance(lastPosition, transform.position) / Time.deltaTime;
        animator.SetFloat("speed", speed);
        lastPosition = this.transform.position;
    }
}
