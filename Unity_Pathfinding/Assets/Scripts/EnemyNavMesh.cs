using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private float distanceToDestination = 0.1f;
    public Transform p1, p2;
    public float speed;
    float t;
    private bool killMode = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        if (!killMode)
        {
            t = Mathf.PingPong(Time.time * speed, 1.0f);
            transform.position = Vector3.Lerp(p1.position, p2.position, t);
        }
        else
        {
            agent.SetDestination(player.position);
            Debug.Log("Started Moving");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            killMode = true;
        }
    }
}
