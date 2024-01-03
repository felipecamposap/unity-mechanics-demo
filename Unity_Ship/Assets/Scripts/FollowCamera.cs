using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;

    private float posX, posY, posZ;
    private Vector3 destination;
    [SerializeField] private float yOffset = 0;

    void Start()
    {
        posZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        posX = target.transform.position.x;
        posY = target.transform.position.y + yOffset;

        transform.position = new Vector3(posX, posY, posZ);
    }

    void FixedUpdate()
    {
    }
}
