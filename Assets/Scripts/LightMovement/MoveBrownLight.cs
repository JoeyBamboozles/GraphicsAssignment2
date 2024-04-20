using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBrownLight : MonoBehaviour
{
    private float moveSpeed = 195f;
    private float maxZ = 269.4f;
    private float minZ = 0f;
    private Vector3 moveDirection = new Vector3(5.1f, 0f, 1f);

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