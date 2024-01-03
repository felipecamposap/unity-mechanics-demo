using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public Transform target;
    public float speed;
    Vector3 dir;

    private Rigidbody rb;

    [SerializeField] private PuzzleController PC;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target.hasChanged)
        {
            dir = new Vector3(target.position.x - transform.position.x, 0, target.position.z - transform.position.z);
        }

        transform.position += dir * speed * Time.fixedDeltaTime;
    }
}
