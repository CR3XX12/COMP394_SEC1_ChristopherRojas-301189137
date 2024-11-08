using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveWithSin : MonoBehaviour
{
    public float speed = 5f;
    public float maxHorizontalDistance = 4f;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = this.transform.position;
    }

    void FixedUpdate()
    {
        if (maxHorizontalDistance > 0)
        {
            float newX = maxHorizontalDistance * Mathf.Sin(Time.fixedTime * speed);
            this.transform.position = originalPos + new Vector3(newX, 0, 0);
        }
    }
}

