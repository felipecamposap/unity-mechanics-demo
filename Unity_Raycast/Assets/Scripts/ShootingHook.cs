using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHook : MonoBehaviour
{
    public ItemPull itemPull;
    public float pullRange;           // Maximum range of the grappling hook
    public LayerMask pullableLayers;         // Layers that can be grappled

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // cast a ray towards the mouse position and check if it hits an object tagged "Grabbable"
            if (Physics.Raycast(ray, out hit, pullRange, pullableLayers))
            {
                itemPull.ActivatePull(hit.collider.gameObject);
            }
        }
        else if (Input.GetMouseButtonDown(1) && itemPull != null)
        {
            // release the object on right mouse click
            itemPull.DeactivatePull();
        }
    }
}
