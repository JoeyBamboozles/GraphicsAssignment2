using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPhongGem : MonoBehaviour
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
        float scaleValueX = 5.0f;
        float scaleValueY = 5.0f;
        float scaleValueZ = 5.0f;
        float rotationSpeedY = 3000.0f;
        float circularSpeed = 3.0f;

      
        Matrix4x4 scale = Matrix4x4.Scale(new Vector3(scaleValueX, scaleValueY, scaleValueZ));
        Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(0.0f, Time.time * rotationSpeedY, 0.0f));
        Matrix4x4 translation = Matrix4x4.Translate(new Vector3(
            5.0f * Mathf.Cos(Time.time * circularSpeed), 
            0.0f,
            5.0f * Mathf.Sin(Time.time * circularSpeed) 
        ));

       mesh.vertices = Transform(translation * rotation * scale, original);
    }
}
