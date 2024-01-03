using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
    public float speed = 10f;
    public GameObject player;
    public float holdDistance = 2f; // distance in front of player to hold the item

    private GameObject targetObject = null;
    private Vector3 holdPosition;
    private bool isReturning = false;
    private bool isHolding = false;

    void Update()
    {
        if (targetObject != null)
        {
            // move towards target object
            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetObject.transform.position) < 100f)
            {
                isHolding = true;
                targetObject.transform.SetParent(transform);
            }
        }
        else if (isHolding)
        {
            // move to the hold position
            transform.position = Vector3.MoveTowards(transform.position, holdPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, holdPosition) < 0.1f)
            {
                isReturning = true;
            }
        }
        else if (isReturning)
        {
            // return to player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ActivateHook(GameObject target)
    {
        gameObject.SetActive(true);
        targetObject = target;
        holdPosition = player.transform.position + player.transform.forward * holdDistance;
    }

    public void DeactivateHook()
    {
        if (isHolding)
        {
            targetObject.transform.SetParent(null);
            targetObject = null;
        }
        gameObject.SetActive(false);
        isReturning = false;
        isHolding = false;
    }
}
