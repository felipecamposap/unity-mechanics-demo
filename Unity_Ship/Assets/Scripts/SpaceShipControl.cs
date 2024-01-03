using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControl : MonoBehaviour
{
    [Header("Propriedades de Movimentação")]
    [SerializeField] private float thrustForce;
    [SerializeField] private float rotationForce;

    Rigidbody rigidBody;

    [Header("Propulsores")]
    [SerializeField] private GameObject propulsorEsquerdo;
    [SerializeField] private GameObject propulsorMeio;
    [SerializeField] private GameObject propulsorDireito;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        propulsorEsquerdo.SetActive(false);
        propulsorMeio.SetActive(false);
        propulsorDireito.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, 1 * rotationForce * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -1 * rotationForce * Time.fixedDeltaTime);
        }

    }
}
