using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class QuitGameController : MonoBehaviour
{
     public void OnQuitButtonClick()
    {
        Debug.Log("Quit Button was clicked!");

        // This will quit the game if it is running in a built version
        Application.Quit();

#if UNITY_EDITOR
        // This will stop Play mode in the Unity Editor
        EditorApplication.isPlaying = false;
#endif
    }
}
