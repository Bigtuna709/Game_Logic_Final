using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public List<Transform> npcCheckPoints = new List<Transform>();
    public int enemyDamage;
    public float distanceCheck;
    public float waitAtDestinationTime;
    public bool chooseRandomDestination;

    public GameObject playerTarget;
    public GameObject enemyEyes;
    public int checkPointDestination;
    public float minDistanceToPlayer;
    private NavMeshAgent npcAgent;
    public Animator animator;

    private void Awake()
    {
        npcAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        npcAgent.destination = npcCheckPoints[checkPointDestination].position;
    }
    private void Update()
    {
        ChooseDestinationOrTarget();
    }

    private void ChooseDestinationOrTarget()
    {
        //AI will either choose to follow the player or go to its waypoint based on player distance
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);
        if (distanceToPlayer < minDistanceToPlayer)
        {
            SpotPlayerTarget();
        }
        else
        {
            ChooseRandomDestinationOrNot();
        }
    }

    private void ChooseRandomDestinationOrNot()
    {
        //Choose whether or not the AI chooses random checkpoints
        animator.SetBool("isChasingPlayer", false);
        if (!chooseRandomDestination)
        {
            StartCoroutine(NotRandomDestination());
        }
        else
        {
            StartCoroutine(RandomDestination());
        }
    }

    public void SpotPlayerTarget()
    {
        npcAgent.destination = npcCheckPoints[checkPointDestination].position;
        // Uses raycast to detect player
        RaycastHit hit;
        Debug.DrawRay(enemyEyes.transform.position, playerTarget.transform.position - enemyEyes.transform.position, Color.red, 10f);
        if(Physics.Raycast(enemyEyes.transform.position, playerTarget.transform.position - enemyEyes.transform.position, out hit))
        {
            if(hit.transform.CompareTag("Player"))
            {
                // Turn on the "munch" animation if the player is spotted
                if (animator.GetBool("isChasingPlayer") == false)
                {
                    animator.SetBool("isChasingPlayer", true);
                }
                npcAgent.destination = playerTarget.transform.position;
            }
        }
    }
    private IEnumerator RandomDestination()
    {
        //Picks a random checkpoint for the AI
        TurnOffMunching();
        npcAgent.destination = npcCheckPoints[checkPointDestination].position;
        float distance = Vector3.Distance(npcCheckPoints[checkPointDestination].position, transform.position);
        if (distance < distanceCheck)
        {
            int newCheckPoint = Random.Range(0, npcCheckPoints.Count);
            checkPointDestination = newCheckPoint;
            yield return new WaitForSeconds(waitAtDestinationTime);
            npcAgent.destination = npcCheckPoints[checkPointDestination].position;
        }
    }

    public void TurnOffMunching()
    {
        //Turns off the enemy "munch" animation
        if (animator.GetBool("isChasingPlayer") == true)
        {
            animator.SetBool("isChasingPlayer", false);
        }
    }

    private IEnumerator NotRandomDestination()
    {
        //The enemy will cycle through its checkpoints
        TurnOffMunching();
        npcAgent.destination = npcCheckPoints[checkPointDestination].position;
        float distance = Vector3.Distance(npcCheckPoints[checkPointDestination].position, transform.position);
        if (distance < distanceCheck)
        {
            checkPointDestination++;
            if (checkPointDestination == npcCheckPoints.Count)
            {
                checkPointDestination = 0;
            }
            yield return new WaitForSeconds(waitAtDestinationTime);
            npcAgent.destination = npcCheckPoints[checkPointDestination].position;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Check to see if it hit the player and adds damage
            Debug.Log("<color=red>Enemy hit player!</color>");
            StartCoroutine(GameManager.Instance.PlayerTakeDamage(enemyDamage));
        }
    }
}
