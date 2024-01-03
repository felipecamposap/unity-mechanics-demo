using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public float throwForce = 15.0f;
    public float dropForce = 10.0f;
    public Transform holdPosition;

    private GameObject heldItem;
    private Rigidbody heldItemRigidbody;

    void Start()
    {
        if (holdPosition == null)
        {
            Debug.LogError("Hold position Transform is not set. Please set a Transform for the hold position.");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (heldItem != null)
            {
                DropItem();
            }
        }
        if (Input.GetButtonDown("Fire2") && heldItem != null)
        {
            ThrowItem();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Entrei {other.CompareTag("Pickupable")}\t{other.tag}");
        if (heldItem == null && other.CompareTag("Pickupable"))
        {
            PickUpItem(other.gameObject);
        }
    }

    private void PickUpItem(GameObject item)
    {
        heldItem = item;
        heldItemRigidbody = heldItem.GetComponent<Rigidbody>();

        heldItemRigidbody.isKinematic = true;
        heldItemRigidbody.useGravity = false;
        heldItem.transform.SetParent(holdPosition);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;
    }

    private void DropItem()
    {
        heldItemRigidbody.isKinematic = false;
        heldItemRigidbody.useGravity = true;
        heldItem.transform.SetParent(null);
        heldItemRigidbody.AddForce(holdPosition.forward * dropForce, ForceMode.Impulse);
        heldItem = null;
    }

    private void ThrowItem()
    {
        heldItemRigidbody.isKinematic = false;
        heldItemRigidbody.useGravity = true;
        heldItem.transform.SetParent(null);
        heldItemRigidbody.AddForce(holdPosition.forward * throwForce, ForceMode.Impulse);
        heldItem = null;
    }
}