using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour {

    public Transform _toilet;


	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("moved the game object a bit");
            _toilet.localPosition += new Vector3(0f, 0f, .1f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("moved the game object a bit");
            _toilet.localPosition += new Vector3(0f, 0f, -.1f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("moved the game object a bit");
            _toilet.localPosition += new Vector3(-0.1f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("moved the game object a bit");
            _toilet.localPosition += new Vector3(0.1f, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("rotated the game object a bit");
            _toilet.Rotate (new Vector3(0f,-1f,0f), 10f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("rotated the game object a bit");
            _toilet.Rotate(new Vector3(0f, 1f, 0f), 10f);
        }
    }

    //functions to play with
    public void RotateRight()
    {
        Debug.Log("rotated the game object a bit");
        _toilet.Rotate(new Vector3(0f, 1f, 0f), 10f);
    }
    public void RotateLeft()
    {
        Debug.Log("rotated the game object a bit");
        _toilet.Rotate(new Vector3(0f, -1f, 0f), 10f);
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
