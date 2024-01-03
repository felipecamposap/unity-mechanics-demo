using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{
    bool isPressing = false;
    private Vector3 objectPosition;
    private GameObject currentMovable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("Pickupable") && !isPressing)
                {
                    ChangeObject(hit.collider.gameObject);
                    objectPosition = new Vector3(hit.point.x, hit.point.y, 0);
                    currentMovable.transform.position = objectPosition;
                    currentMovable.transform.rotation = new Quaternion(0, 0, 0, 0);
                    isPressing = true;
                }
                
            }
        }

        if(isPressing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            currentMovable.transform.position = ray.GetPoint(5);
            currentMovable.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(Input.GetMouseButtonUp(1))
        {
            isPressing = false;

            try
            {
                currentMovable.GetComponentInParent<Rigidbody>().isKinematic = false;
            }
            catch(Exception ex)
            {
                Debug.Log(ex);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(7);
        }
    }

    void ChangeObject(GameObject newObject)
    {
        if(currentMovable != null)
        {
            currentMovable.GetComponent<Rigidbody>().isKinematic = false;
        }

        newObject.GetComponent<Rigidbody>().isKinematic = true;
        currentMovable = newObject;
    }

}
