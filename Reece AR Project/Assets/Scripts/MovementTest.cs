using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

    public Transform _toilet;

	void Update () {
        RotateShit();
	}

    public void RotateShit()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Moved the toilet a bit");
            _toilet.localPosition += new Vector3(.2f, 0f, 0f);

            _toilet.Rotate(new Vector3(.04325f, 0.5f, 0.1f), 10f);
        }
    }

    public void MoveBack()
    {
        Debug.Log("moved the game object a bit");
        _toilet.localPosition += new Vector3(0f, 0f, .1f);
    }
    public void MoveForward()
    {
        Debug.Log("moved the game object a bit");
        _toilet.localPosition += new Vector3(0f, 0f, -.1f);
    }
    public void MoveLeft()
    {
        Debug.Log("moved the game object a bit");
        _toilet.localPosition += new Vector3(-0.1f, 0f, 0f);
    }
    public void MoveRight()
    {
        Debug.Log("moved the game object a bit");
        _toilet.localPosition += new Vector3(0.1f, 0f, 0f);
    }

}
