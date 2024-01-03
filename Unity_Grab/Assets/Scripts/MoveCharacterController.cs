using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 2.5f;
    private float gravityValue = -9.81f;
    private bool isGrounded;

    [SerializeField] private PuzzleController PC;

    private void Start()
    {
        controller = gameObject.GetComponentInParent<CharacterController>();
    }

    void Update()
    {
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Pulou");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("nochao");
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            PC.Defeat();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            PC.PuzzleCount++;
            Destroy(other.gameObject);
        }
    }

}
