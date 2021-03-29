using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public PlayerButton moveUpButton;
    public PlayerButton moveDownButton;
    public PlayerButton moveLeftButton;
    public PlayerButton moveRightButton;

    private void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void Update()
    {
       // if(Input.GetMouseButtonDown(1))
       // {
       //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       //     RaycastHit hit;
       //     if(Physics.Raycast(ray, out hit, 100))
       //     {
       //         playerNavMesh.SetDestination(hit.point);
       //     }
       // }
    }
    public void MoveUp()
    {
        playerNavMesh.Move(-Vector3.forward);
    }
}
