using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 5f;
    public float maxHorizontalDistance = 4f;
    public float maxVerticalDistance = 5f;
    private Vector3 originalPos;

    void Start()
    {
        originalPos = this.transform.position;
    }

    void FixedUpdate()
    {
        if (maxHorizontalDistance > 0)
        {
            float newX = Mathf.PingPong(Time.fixedTime * speed, maxHorizontalDistance);
            this.transform.position = originalPos + new Vector3(newX, 0, 0);
        }
        else if (maxVerticalDistance > 0)
        {
            float newY = Mathf.PingPong(Time.fixedTime * speed, maxVerticalDistance);
            this.transform.position = originalPos + new Vector3(0, newY, 0);
        }
    }
}

