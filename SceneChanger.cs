using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public void LoadNextScene() {
        /* Loads the next scene that comes after the Scene that we are currently in */
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void LoadStartScene() {
        /* Loads the initial Start Scene*/
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        /* Quits the game */
        Application.Quit();
    }
}
