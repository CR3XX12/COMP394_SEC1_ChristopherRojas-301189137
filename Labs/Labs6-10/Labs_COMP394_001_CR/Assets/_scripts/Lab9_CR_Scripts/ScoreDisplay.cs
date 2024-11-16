using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;       
    public GameObject winMessage; 
    private int totalItems;     

    void Start()
    {
        // Dynamically count all collectibles tagged as "Collectible"
        totalItems = GameObject.FindGameObjectsWithTag("Collectible").Length;

        // Set initial score and hide the win message
        scoreText.text = "Score: 0";
        if (winMessage != null)
        {
            winMessage.SetActive(false);
        }
    }

    void Update()
    {
        // Update the score display
        scoreText.text = "Score: " + GameManager.Instance.score;

        // Check if the player has collected all items
        if (GameManager.Instance.score >= totalItems)
        {
            // Display "You Win!" message
            if (winMessage != null)
            {
                winMessage.SetActive(true);
            }
        }
    }
}


