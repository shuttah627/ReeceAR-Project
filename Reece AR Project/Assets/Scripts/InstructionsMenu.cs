using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour {

    // Back
    public void Back()
    {
        SceneManager.LoadScene(1);
    }
}
