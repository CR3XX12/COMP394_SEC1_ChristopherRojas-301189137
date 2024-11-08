using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{
    public float collapseDelay = 1f; // Time before collapse
    public float respawnDelay = 3f;  

    private Renderer platformRenderer;
    private Collider platformCollider;

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start the collapse process
            Invoke("Collapse", collapseDelay);
        }
    }

    void Collapse()
    {
        // Disable the platform visually and physically
        platformRenderer.enabled = false;
        platformCollider.enabled = false;
        // Schedule the platform to reappear after respawnDelay
        Invoke("Respawn", respawnDelay);
    }

    void Respawn()
    {
        // Re-enable the platform visually and physically
        platformRenderer.enabled = true;
        platformCollider.enabled = true;
    }
}

