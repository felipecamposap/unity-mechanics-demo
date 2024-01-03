using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpring : MonoBehaviour
{
    [SerializeField] private HingeJoint joint;
    [SerializeField] private GameObject alavanca;
    private bool onTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            Debug.Log("Alavanca puxada");
            alavanca.transform.rotation = new Quaternion(-120f, alavanca.transform.rotation.y, alavanca.transform.rotation.z, alavanca.transform.rotation.w);
            joint.useSpring = true;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Finish"))
        {
            onTrigger = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Finish"))
        {
            onTrigger = false;
        }
    }
}
