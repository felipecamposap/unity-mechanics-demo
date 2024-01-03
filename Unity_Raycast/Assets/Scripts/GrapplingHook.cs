using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public float hookRange = 100f;           // Maximum range of the grappling hook
    public float hookSpeed = 20f;            // Speed at which the hook travels
    public float playerPullSpeed = 10f;      // Speed at which the player is pulled towards the hook
    public Transform hookTransform;          // Transform of the hook game object
    public LayerMask hookableLayers;         // Layers that can be grappled

    private bool isGrappling = false;        // Flag to indicate if the player is currently grappling
    private Vector3 grapplingStartPosition;  // Starting position of the grappling hook
    private Rigidbody playerRigidbody;       // Rigidbody of the player

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
            // Pull the player towards the hook
            PullPlayerTowardsHook();
        }
    }

    private void ShootGrapplingHook()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hookRange, hookableLayers))
        {
            grapplingStartPosition = transform.position;
            hookTransform.position = hit.point;
            hookTransform.LookAt(grapplingStartPosition);

            isGrappling = true;
        }
    }

    private void ReleaseGrapplingHook()
    {
        hookTransform.position = transform.position;
        isGrappling = false;
    }

    private void PullPlayerTowardsHook()
    {
        Vector3 direction = hookTransform.position - grapplingStartPosition;
        playerRigidbody.velocity = direction.normalized * playerPullSpeed;
    }
}
