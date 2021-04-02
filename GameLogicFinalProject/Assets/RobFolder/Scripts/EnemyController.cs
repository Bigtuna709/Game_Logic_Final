using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public List<Transform> npcCheckPoints = new List<Transform>();
    public float distanceCheck;
    public float waitAtDestinationTime;
    public bool chooseRandomDestination;

    private GameObject playerTarget;
    public GameObject enemyEyes;
    public int checkPointDestenation;
    public float minDistanceToPlayer;
    private NavMeshAgent npcAgent;

    private void Awake()
    {
        npcAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        npcAgent.destination = npcCheckPoints[checkPointDestenation].position;
    }
    private void Update()
    {
        ChooseDestinationOrTarget();
    }

    private void ChooseDestinationOrTarget()
    {
        if (playerTarget != null)
        {
            npcAgent.destination = playerTarget.transform.position;
        }
        else
        {
            ChooseRandomDestinationOrNot();
        }
    }

    private void ChooseRandomDestinationOrNot()
    {
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
        float distanceToPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);
        if(distanceToPlayer < minDistanceToPlayer)
        {
            RaycastHit hit;
            Debug.DrawRay(enemyEyes.transform.position, playerTarget.transform.position - enemyEyes.transform.position, Color.red, 10f);
            if(Physics.Raycast(enemyEyes.transform.position, playerTarget.transform.position - enemyEyes.transform.position, out hit))
            {
                if(hit.transform.tag == "Player")
                {
                    npcAgent.destination = playerTarget.transform.position;
                }
            }
        }
    }
    private IEnumerator RandomDestination()
    {
        float distance = Vector3.Distance(npcCheckPoints[checkPointDestenation].position, transform.position);
        if (distance < distanceCheck)
        {
            int newCheckPoint = Random.Range(0, npcCheckPoints.Count);
            checkPointDestenation = newCheckPoint;
            yield return new WaitForSeconds(waitAtDestinationTime);
            npcAgent.destination = npcCheckPoints[checkPointDestenation].position;
        }
    }

    private IEnumerator NotRandomDestination()
    {
        float distance = Vector3.Distance(npcCheckPoints[checkPointDestenation].position, transform.position);
        if (distance < distanceCheck)
        {
            checkPointDestenation++;
            if (checkPointDestenation == npcCheckPoints.Count)
            {
                checkPointDestenation = 0;
            }
            yield return new WaitForSeconds(waitAtDestinationTime);
            npcAgent.destination = npcCheckPoints[checkPointDestenation].position;
        }
    }
}
