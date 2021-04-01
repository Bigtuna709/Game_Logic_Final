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

    private GameObject target;
    public int checkPointDestenation;
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
        if (target != null)
        {
            npcAgent.destination = target.transform.position;
        }
        else
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
