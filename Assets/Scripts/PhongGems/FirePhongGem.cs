using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePhongGem : MonoBehaviour
{
    Mesh mesh;
    Vector3[] original;
    float minHeight = -5.0f; 
    float maxHeight = 10.0f; 
    float bounceSpeed = 3.0f; 
    float rotationSpeed = 100.0f; 

    MeshRenderer meshRenderer;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        original = mesh.vertices;
        meshRenderer = GetComponent<MeshRenderer>(); 
    }

    Vector3[] Transform(Matrix4x4 matrix, Vector3[] inputVertices, float scaleX, float scaleY, float scaleZ)
    {
        Vector3[] outputVertices = new Vector3[inputVertices.Length];
        for (int i = 0; i < outputVertices.Length; i++)
        {
            Vector4 vertex = new Vector4(
                inputVertices[i].x * scaleX,
                inputVertices[i].y * scaleY,
                inputVertices[i].z * scaleZ,
                1.0f
            );

            outputVertices[i] = matrix * vertex;
        }
        return outputVertices;
    }

    void Update()
    {
        float scaleX = 3.0f;
        float scaleY = 3.0f;
        float scaleZ = 3.0f;

        float heightOffset = Mathf.Sin(Time.time * bounceSpeed); 
        float height = Mathf.Lerp(minHeight, maxHeight, (heightOffset + 1) / 2); 

        Matrix4x4 translation = Matrix4x4.Translate(new Vector3(0.0f, height, 0.0f));
        Matrix4x4 rotation = Matrix4x4.Rotate(Quaternion.Euler(0.0f, Time.time * rotationSpeed, 0.0f));
        mesh.vertices = Transform(rotation * translation, original, scaleX, scaleY, scaleZ);

        float visibilityThreshold = minHeight + (maxHeight - minHeight) * 0.3f; 
        
        if (height < visibilityThreshold)
        {
            meshRenderer.enabled = false; 
        }
        else
        {
            meshRenderer.enabled = true; 
        }
    }
}
