using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Fugir : MonoBehaviour
 {
 public Transform target;
 public float speed;

 private void FixedUpdate()
 {
 if (target.hasChanged)
 {
 // O atributo normalize permite que a velocidade de colisao seja continua
 // Sem ele, ocorre uma diminuicao da velocidade quando um objeto chega proximo de outro
 //dir = (transform.position - target.position).normalized;
 }
//
 //transform.position += dir * speed * Time.fixedDeltaTime;

 }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            Vector3 objectPosition = ray.GetPoint(10);
            transform.position = objectPosition; // Move this object to the hit position.
        }
    }

}