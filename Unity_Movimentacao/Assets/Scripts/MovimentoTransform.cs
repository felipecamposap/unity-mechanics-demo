using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class MovimentoTransform : MonoBehaviour
 {
 // [SerializeField] torna um atributo private visivel no Inspector
 [SerializeField] private float velocidade = 5f;
 // Start is called before the first frame update
 void Start()
 {

 }

 // Update is called once per frame
 void Update()
 {
 float horizontal = Input.GetAxis("Horizontal");
 float vertical = Input.GetAxis("Vertical");

 Vector3 direction = new Vector3(horizontal, 0, vertical);


 transform.Translate(direction * velocidade * Time.deltaTime);
 }
 }
