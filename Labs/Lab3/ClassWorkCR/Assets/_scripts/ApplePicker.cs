using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
     [Header("Set in Inspector")] // a
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start () {
        for (int i=0; i<numBaskets; i++) {
        GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY + ( basketSpacingY * i );
        tBasketGO.transform.position = pos;
        }
    }
    public void AppleDestroyed() {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO); // Destroy each apple
        }
        // Destroy one of the baskets
        int basketIndex = basketList.Count - 1;  // e - Get the index of the last basket in the list
        GameObject tBasketGO = basketList[basketIndex]; // Reference the last basket GameObject
        basketList.RemoveAt(basketIndex); // Remove it from the list
        Destroy(tBasketGO);               // Destroy the GameObject

        // If no baskets are left, restart the game
        if (basketList.Count == 0) {
            SceneManager.LoadScene("_Scene_0"); // Restart the game
        }
    
    }
    }

