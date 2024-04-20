using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phong : MonoBehaviour
{
    [Range(0.0f, 1.0f)] public float ambientIntensity;
    [Range(0.0f, 1.0f)] public float diffuseIntensity;
    [Range(0.0f, 256.0f)] public float specularPower;

    public Color lightColor;
    public Transform lightTransform;
    public Transform cameraTransform;

    Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (lightTransform == null || cameraTransform == null || material == null)
            return;

        Vector3 position = transform.position;
        Vector3 N = transform.up.normalized; 

        Vector3 L = (lightTransform.position - position).normalized;
        Vector3 V = (cameraTransform.position - position).normalized;
        Vector3 R = Vector3.Reflect(-L, N);

        float dotNL = Mathf.Max(0.0f, Vector3.Dot(N, L));
        float dotVR = Mathf.Max(0.0f, Vector3.Dot(V, R));

        Color ambient = lightColor * ambientIntensity;
        Color diffuse = lightColor * diffuseIntensity * dotNL;
        Color specular = lightColor * Mathf.Pow(dotVR, specularPower);

        material.color = ambient + diffuse + specular;
    }
}

