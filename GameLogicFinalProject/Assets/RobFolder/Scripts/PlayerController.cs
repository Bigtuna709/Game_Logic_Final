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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        if (moveUpButton.IsPressed)
        {
            velocity.z -= playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (moveDownButton.IsPressed)
        {
            velocity.z += playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(-Vector3.forward);
        }
        if (moveLeftButton.IsPressed)
        {
            velocity.x += playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(-Vector3.right);
        }
        if (moveRightButton.IsPressed)
        {
            velocity.x -= playerMovementSpeed;
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }

        rb.velocity = velocity * Time.deltaTime;
    }
}
