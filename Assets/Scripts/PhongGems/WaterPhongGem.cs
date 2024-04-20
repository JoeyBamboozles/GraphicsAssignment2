using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhongGem : MonoBehaviour
{
    Mesh mesh;
    Vector3[] original;
    float minScale = 0.01f; 

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


        float flipSpeed = 10.0f;
        
        float lerpT = Mathf.PingPong(Time.time / 5.0f, 1.0f);
        float scaleValue = Mathf.Lerp(1.0f, 4.0f, lerpT);
        float finalScale = Mathf.Lerp(scaleValue, minScale, lerpT); 

        
        Matrix4x4 scale = Matrix4x4.Scale(new Vector3(finalScale, finalScale, finalScale));
        Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(0.0f, 0.0f, Time.time * flipSpeed));
        mesh.vertices = Transform(rotation * scale, original);
    }
}
