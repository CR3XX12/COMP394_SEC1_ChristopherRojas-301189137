using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    public float tiltSpeed = 5f;
    public float maxTiltAngle = 15f; 

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        // Create a smooth tilting effect using Mathf.Sin
        float tiltAngle = maxTiltAngle * Mathf.Sin(Time.time * tiltSpeed);
        transform.rotation = originalRotation * Quaternion.Euler(0, 0, tiltAngle);
    }
}

