using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAndArrow : MonoBehaviour
{
    private float throwForce = 5.0f;
    private float iThrowForce;
    [SerializeField] private float maxThrowForce = 15f;
    [SerializeField] private float throwForceIncrement = 0.2f;
    public float dropForce = 10.0f;
    public Transform holdPosition;

    private GameObject heldItem;
    private Rigidbody heldItemRigidbody;


    void Start()
    {
        iThrowForce = throwForce;
        if (holdPosition == null)
        {
            Debug.LogError("Hold position Transform is not set. Please set a Transform for the hold position.");
        }
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            if(throwForce < maxThrowForce)
            {
                throwForce += throwForceIncrement;
                Debug.Log(throwForce);
            }
                
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            ThrowItem();
            throwForce = iThrowForce;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (heldItem == null && other.CompareTag("Pickupable"))
        {
            PickUpItem(other.gameObject);
        }
    }

    private void PickUpItem(GameObject item)
    {
        throwForce = iThrowForce;
        heldItem = item;
        heldItemRigidbody = heldItem.GetComponent<Rigidbody>();

        heldItemRigidbody.isKinematic = true;
        heldItemRigidbody.useGravity = false;
        heldItem.transform.SetParent(holdPosition);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
    }

    private void ThrowItem()
    {
        if(heldItem != null)
        {
            heldItemRigidbody.isKinematic = false;
            heldItemRigidbody.useGravity = true;
            heldItem.transform.SetParent(null);
            heldItemRigidbody.AddForce(holdPosition.forward * throwForce, ForceMode.Impulse);
            heldItem = null;
        }
    }
}