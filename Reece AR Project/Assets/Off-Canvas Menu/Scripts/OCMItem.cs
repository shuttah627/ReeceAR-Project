using UnityEngine;
using UnityEngine.SceneManagement;

public class OCMItem : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DebugLog(string text)
    {
        Debug.Log(text);
    }
}

// Default
/*
 * using UnityEngine;
using UnityEngine.SceneManagement;

public class OCMItem : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DebugLog(string text)
    {
        Debug.Log(text);
    }
}

    */
