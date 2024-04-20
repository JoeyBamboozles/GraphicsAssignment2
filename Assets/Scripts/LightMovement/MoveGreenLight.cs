using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGreenLight : MonoBehaviour
{
    private float moveSpeed = 700f;
    private float maxZ = 0f;
    private float minZ = -955.7f;
    private Vector3 moveDirection = new Vector3(0.37f, 0f, -1f);

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
