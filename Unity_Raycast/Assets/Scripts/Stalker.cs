using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stalker : MonoBehaviour
{
    public Transform target;
    public float speed;
    Vector3 dir;

    private Rigidbody rb;


    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (target.hasChanged)
        {
            try
            {

                dir = target.position - transform.position;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        transform.position += dir * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Derrota"))
        {
            Destroy(gameObject);
        }
    }
}
