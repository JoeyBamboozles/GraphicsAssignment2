using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYellowLight : MonoBehaviour
{
    private float moveSpeed = 550f;
    private float maxZ = 0f;
    private float minZ = -753.5f;
    private Vector3 moveDirection = new Vector3(-0.94f, 0f, -1f);

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;

        transform.position += moveDirection * step;

        if (transform.position.z >= originalPosition.z + maxZ || transform.position.z <= originalPosition.z + minZ)
       
        {
            transform.position = originalPosition; 
        }
    }
}
