using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPhongGem : MonoBehaviour
{
    Mesh mesh;
    Vector3[] original;
    float scale = 7.5f;
    float moveRadius = 1.0f; 
    float moveSpeed = 1.0f; 

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
                inputVertices[i].x * scale,
                inputVertices[i].y * scale,
                inputVertices[i].z * scale,
                1.0f
            );

            outputVertices[i] = matrix * vertex;
        }
        return outputVertices;
    }

    void Update()
    {
        float rotationAngleX = Mathf.PingPong(Time.time * 5.0f, 90.0f) - 90.0f; // Alternates between -90 and 0
        float rotationAngleZ = Mathf.PingPong(Time.time * 5.0f, 90.0f); // Alternates between 0 and 90
        Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(rotationAngleX, 0.0f, rotationAngleZ));

        float offsetX = Mathf.Sin(Time.time * moveSpeed) * moveRadius;
        float offsetZ = Mathf.Cos(Time.time * moveSpeed) * moveRadius;
        Matrix4x4 translation = Matrix4x4.Translate(new Vector3(offsetX, 0.0f, offsetZ));

        mesh.vertices = Transform(rotation * translation, original);
    }
}
