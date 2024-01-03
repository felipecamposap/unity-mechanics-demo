using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AutoMovementNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    private byte index = 0;
    [SerializeField] private Transform[] path;
    private Transform currentDestination;
    [SerializeField] private float distanceToDestination = 0.1f;

    void Start()
    {
        currentDestination = path[index].transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(currentDestination.position);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, currentDestination.position) > distanceToDestination)
        {
            currentDestination = path[index].transform;
            agent.isStopped = false;
            agent.SetDestination(currentDestination.position);
        }
        else if(index == path.Length - 1)
        {
            agent.isStopped = true;
        }
        else
        {
            index++;
            currentDestination = path[index].transform;
            agent.isStopped = false;
            agent.SetDestination(currentDestination.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Derrota"))
        {
            path[0].GetComponentInChildren<PlayerMovementNavMesh>().Derrota();
        }
        else if (other.CompareTag("Vitoria"))
        {
            path[0].GetComponentInChildren<PlayerMovementNavMesh>().Vitoria();
        }
    }
}
