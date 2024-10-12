using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;  
#endif

public class ButtonController : MonoBehaviour
{        
#if UNITY_EDITOR
    public SceneAsset sceneToLoad;  // Assign the scene in the Inspector (Editor-only field)
#endif

    [HideInInspector]
    public string sceneName;  // Hidden field that stores the actual scene name

    // This method is called when the button is clicked
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);  // Loads the specified scene
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }

#if UNITY_EDITOR
    // This method runs in the editor and updates the scene name based on SceneAsset
    private void OnValidate()
    {
        if (sceneToLoad != null)
        {
            // Get the scene path and extract just the name of the scene
            sceneName = AssetDatabase.GetAssetPath(sceneToLoad);
            sceneName = System.IO.Path.GetFileNameWithoutExtension(sceneName);
        }
    }
#endif
    

 
}
