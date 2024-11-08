using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformExpand : MonoBehaviour
{
    public float expansionSpeed = 2f;        
    public float minScale = 1f;                
    public float maxScale = 2f;               

    private Vector3 originalScale;            
    void Start()
    {
        // Store the original scale of the platform
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Calculate a scale factor using Mathf.PingPong
        //float scale = Mathf.PingPong(Time.time * expansionSpeed, maxScale - minScale) + minScale;
        // Calculate a smooth scale factor using Mathf.Sin for a sine wave effect
        float scale = ((Mathf.Sin(Time.time * expansionSpeed) + 1) / 2) * (maxScale - minScale) + minScale;


        // Apply the new scale uniformly to all axes
        transform.localScale = originalScale * scale;
    }
}

