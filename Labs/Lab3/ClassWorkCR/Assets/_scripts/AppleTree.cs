using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab; // Prefab for regular apple
    public GameObject goldenApplePrefab; // Prefab for golden apple
    public float speed = 1f; // Speed at which the AppleTree moves
    public float leftAndRightEdge = 10f; // Distance where AppleTree turns around
    public float chanceToChangeDirections = 0.1f; // Chance to change direction
    public float secondsBetweenAppleDrops = 1f; // Time between apple drops

    // Public static reference to allow access from ApplePicker
    public static AppleTree instance;

    void Awake() {
        instance = this;
    }

    void Start() 
    {
        Invoke("DropApple", 2f); // Drop the first apple after 2 seconds
    }

    void DropApple() 
    {
        GameObject apple;
        if (Random.value < 0.1f) { // 10% chance to drop a golden apple
            apple = Instantiate<GameObject>(goldenApplePrefab);
        } else {
            apple = Instantiate<GameObject>(applePrefab);
        }
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update() 
    {
        if (secondsBetweenAppleDrops > 0.2f) { // Set a minimum limit for apple drop speed
            secondsBetweenAppleDrops -= 0.01f * Time.deltaTime; // Speed up apple drops over time
        }

        // Basic movement of the AppleTree
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Change direction if at edge
        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed); // Move right
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate() 
    {
        if (Random.value < chanceToChangeDirections) {
            speed *= -1; // Change direction randomly
        }
    }
}
