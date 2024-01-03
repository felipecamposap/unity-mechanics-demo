using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class IdaEVolta : MonoBehaviour
 {
    private Vector3 p1, p2;
    public float speed;
    float t;

    void Awake()
    {
        p1 = transform.position;
        p1.y += 3f;
        p2 = transform.position;
    }

 private void FixedUpdate()
    {
        t = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(p1, p2, t);
    }

 }
