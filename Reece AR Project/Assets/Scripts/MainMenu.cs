using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Base Controller (for easy access to audio controller etc.)
    public GameObject _baseController;

    // Sound effects
    public AudioClip _acceptPop;
    public AudioClip _backPop;

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

    public void QueueAcceptSound()
    {
        _baseController.GetComponent<BaseController>()._audioController.GetComponent<AudioController>().AddToQueue(_acceptPop);
    }

    public void QueueBackSound()
    {
        _baseController.GetComponent<BaseController>()._audioController.GetComponent<AudioController>().AddToQueue(_backPop);
    }
}
