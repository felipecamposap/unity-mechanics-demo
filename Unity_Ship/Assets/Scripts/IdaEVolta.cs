using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class IdaEVolta : MonoBehaviour
 {
 public Transform p1, p2;
 public float speed;
 float t;

    [SerializeField] private Slider sld;

 private void FixedUpdate()
 {
     t = Mathf.PingPong(Time.time * speed, 1.0f);
     transform.position = Vector3.Lerp(p1.position, p2.position, t);
 }

    public void SetSpeed()
    {
        speed = sld.value;
    }

 }
