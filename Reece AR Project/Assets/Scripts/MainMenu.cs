using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    // Open default scene
    public void OpenMainAR()
    {
        SceneManager.LoadScene(0);
    }

    // Load selected scene
    public void LoadSaved(/*pass through selected scene*/)
    {
        SceneManager.LoadScene(0/*passed scene*/);                  // TEMP - should be loading a saved file
    }

    // Back
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    // Quit
    public void QuitApplication()
    {
        Application.Quit();
    }
}
