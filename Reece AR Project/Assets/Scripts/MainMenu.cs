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

    // Quit
    public void QuitApplication()
    {
        Application.Quit();
    }
}
