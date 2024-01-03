using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Check for spacebar input to activate the bird's wings.
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector3(10f, 10f, 0f);
        }
        else
        {
            rb.velocity = new Vector3(10f, -9.81f, 0f);
        }
    }
}