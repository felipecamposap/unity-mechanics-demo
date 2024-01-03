using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPull : MonoBehaviour
{
    public float speed = 10f;
    public float holdDistance = 1f; // distance from player at which the object will stop moving
    private GameObject targetObject = null;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Initialize the line renderer
        lineRenderer = this.gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        // Set the color of the line
        //lineRenderer.startColor = Color.green;  // The start of the line is red
        //lineRenderer.endColor = Color.green;   // The end of the line is blue

    }

    void Update()
    {
        if (targetObject != null)
        {
            // check if the target object is within holdDistance of the player
            if (Vector3.Distance(transform.position, targetObject.transform.position) > holdDistance)
            {
                // if not, move the target object towards the player's current position
                targetObject.transform.position = Vector3.MoveTowards(targetObject.transform.position, transform.position, speed * Time.deltaTime);
            }

            // Draw line from player to target object
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, targetObject.transform.position);
        }
        else
        {
            // Hide line when no object is being pulled
            lineRenderer.enabled = false;
        }
    }

    public void ActivatePull(GameObject target)
    {
        targetObject = target;
    }

    public void DeactivatePull()
    {
        targetObject = null;
    }
}
