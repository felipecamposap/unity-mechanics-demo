using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class MRULerp : MonoBehaviour
 {
   [SerializeField] [Range(0f, 1f)] private float t;
   [SerializeField] private Transform p1, p2;

   [SerializeField] private Slider sld;

 // Start is called before the first frame update
 void Start()
 {
    
 }

    public void SetT()
    {
        t = sld.value;
    }

 // Update is called once per frame
 void Update()
 {
    // Implementando o MRU (p = p0 + v * t): transform.position =
    //p1.position + v * t;

    // Com a função Lerp -> p = p1 + (p2 - p1) * t
    transform.position = Vector3.Lerp(p1.position, p2.position, t);
 }
 }
