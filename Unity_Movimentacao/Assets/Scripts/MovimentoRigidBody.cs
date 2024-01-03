using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MovimentoRigidBody : MonoBehaviour
 {
 [SerializeField] private float speed = 5f;
 Rigidbody rb;

 // Start is called before the first frame update
 void Start()
 {
 rb = GetComponent<Rigidbody>();
 }

 // Utilizando o FixedUpdate para garantir que o calculo da fisica sera sempre executado em um intervalo de 0.2 segundos
 void FixedUpdate()
 {
 float horizontal = Input.GetAxis("Horizontal");
 float vertical = Input.GetAxis("Vertical");

 Vector3 direction = new Vector3(horizontal, 0, vertical);

 /* Existem varias formas de movimentar um componente RigidBody. Aqui
mostro os 3 principais */

 // 1. Utilizando o MovePosition
 rb.MovePosition(transform.position + direction * speed *
Time.deltaTime);

 // 2. Alterando a velocidade
 //rb.velocity = direction * speed;
 // 2.1. Alterando a velocidade para cada eixo
 //rb.velocity = new Vector3(horizontal * speed, rb.velocity.y, vertical * speed);

 // 3. Alterando a forca aplicada
 //rb.AddForce(direction * speed);
 }
 }