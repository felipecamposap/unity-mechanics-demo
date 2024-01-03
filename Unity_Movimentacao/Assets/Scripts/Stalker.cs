using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    dir = target.position - transform.position;
 }

 transform.position += dir * speed * Time.fixedDeltaTime;

 }
}
