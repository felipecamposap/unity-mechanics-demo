using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Vector2 pos;
    [SerializeField] private GameObject toFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(toFollow.transform.hasChanged)
        {
        this.transform.position = new Vector3(toFollow.transform.position.x, transform.position.y, toFollow.transform.position.z);

        }
    }
}
