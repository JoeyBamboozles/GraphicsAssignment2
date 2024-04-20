using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturePhongGem : MonoBehaviour
{
    Mesh mesh;
    Vector3[] original;
    
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        original = mesh.vertices;
    }

    Vector3[] Transform(Matrix4x4 matrix, Vector3[] inputVertices)
    {
        Vector3[] outputVertices = new Vector3[inputVertices.Length];
        for (int i = 0; i < outputVertices.Length; i++)
        {
            Vector4 vertex = new Vector4(
                inputVertices[i].x,
                inputVertices[i].y,
                inputVertices[i].z,
                1.0f
            );

            outputVertices[i] = matrix * vertex;
        }
        return outputVertices;
    }

    void Update()
    {
        float scaleX = 3.6f;
        float scaleY = 0.65f;
        float scaleZ = 0.75f;

       
        float swayMovement = Mathf.PingPong(Time.time * 2.0f, 10.0f) - 5.0f; 
        Vector3 positionOffset = new Vector3(swayMovement, 0.0f, 0.0f); 

        float rotationAngle = Mathf.Sin(Time.time * 2.0f) * 45.0f; 
        Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, rotationAngle);
        mesh.vertices = Transform(Matrix4x4.Translate(positionOffset) * Matrix4x4.Scale(new Vector3(scaleX, scaleY, scaleZ)) * Matrix4x4.Rotate(rotation), original);
    }
}
