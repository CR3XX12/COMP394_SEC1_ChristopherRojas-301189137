using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalMovingPlatform : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 3f;
    public float maxHorizontalDistance = 4f;
    public float maxVerticalDistance = 2f;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        float newX = Mathf.PingPong(Time.time * horizontalSpeed, maxHorizontalDistance);
        float newY = Mathf.PingPong(Time.time * verticalSpeed, maxVerticalDistance);
        transform.position = originalPos + new Vector3(newX, newY, 0);
    }
}

