using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private PuzzleController PC;
    [SerializeField] private string target;

    private bool isGrounded;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(target))
        {
            PC.PuzzleCount++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isGrounded && collision.gameObject.CompareTag("Enemy"))
        {
            PC.PuzzleCount++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
}
