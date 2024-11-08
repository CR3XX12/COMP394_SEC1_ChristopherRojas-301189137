using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT; 
    private AudioSource catchSound; // Reference to the audio source

    void Start() 
    {
        // Find the score text
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";

        // Get the AudioSource component attached to the Basket
        catchSound = GetComponent<AudioSource>();

        // Debugging to ensure AudioSource is found
        if (catchSound == null) {
            Debug.LogError("No AudioSource component found on the Basket GameObject.");
        }
    }

    void Update() 
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z; 
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) 
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple") {
            Destroy(collidedWith);

            // Increase score
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            
            // Play the catch sound
            if (catchSound != null) {
                catchSound.Play(); 
            } else {
                Debug.LogError("No AudioSource attached to Basket.");
            }
        }
    }
}
