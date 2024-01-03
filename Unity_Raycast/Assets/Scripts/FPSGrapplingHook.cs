using System.Collections;
using UnityEngine;

public class FPSGrapplingHook : MonoBehaviour
{
    public float hookRange = 100f;           // Maximum range of the grappling hook
    public float hookSpeed = 20f;            // Speed at which the player is pulled towards the hook
    public LayerMask hookableLayers;         // Layers that can be grappled
    public Transform hookTransformPrefab;    // Prefab for the hook game object
    public Color grapplingLineColor = Color.magenta; // Color of the grappling line

    private bool isGrappling = false;        // Flag to indicate if the player is currently grappling
    private Vector3 grapplingStartPosition;  // Starting position of the grappling hook
    private Rigidbody rb;                    // Rigidbody of the player
    private Transform hookTransform;         // Reference to the active hook GameObject
    private LineRenderer grapplingLine;      // LineRenderer component for the grappling line

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isGrappling)
            {
                // Shoot the grappling hook
                ShootGrapplingHook();
            }
            else
            {
                // Release the grappling hook
                ReleaseGrapplingHook();
            }
        }

        if (isGrappling)
        {
            // Move the player towards the hook point
            PullPlayerTowardsHook();

            // Update the grappling line
            UpdateGrapplingLine();
        }
    }

    private void ShootGrapplingHook()
    {
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the input button you want to use for the raycast (e.g., left mouse button)
        {
            // Cast a ray forward from the camera
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, hookRange, hookableLayers))
            {
                grapplingStartPosition = transform.position;
                hookTransform = Instantiate(hookTransformPrefab, hit.point, Quaternion.identity);

                isGrappling = true;

                // Create a LineRenderer component for the grappling line
                grapplingLine = hookTransform.gameObject.AddComponent<LineRenderer>();
                grapplingLine.material.color = grapplingLineColor;
                grapplingLine.startWidth = 0.1f;
                grapplingLine.endWidth = 0.1f;
            }
        }
    }

    private void ReleaseGrapplingHook()
    {
        isGrappling = false;

        // Destroy the hook GameObject and its LineRenderer
        Destroy(hookTransform.gameObject);
        grapplingLine = null;
    }

    private void PullPlayerTowardsHook()
    {
        Vector3 direction = hookTransform.position - grapplingStartPosition;
        float distanceToHook = direction.magnitude;

        if (distanceToHook > 1f)
        {
            rb.AddForce(direction.normalized * hookSpeed);
        }
        else
        {
            // Stop grappling when the player is close enough to the hook
            ReleaseGrapplingHook();
        }
    }

    private void UpdateGrapplingLine()
    {
        if (grapplingLine != null)
        {
            grapplingLine.SetPosition(0, transform.position);
            grapplingLine.SetPosition(1, hookTransform.position);
        }
    }
}
