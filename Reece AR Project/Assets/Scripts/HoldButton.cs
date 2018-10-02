using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : MonoBehaviour {

    public GameObject _modelController;
    bool _pressedDownMove = false;
    bool _pressedDownLeft = false;
    bool _pressedDownRight = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (_pressedDownMove)
        {
            _modelController.GetComponent<ModelController>().MoveFurniture("point");
            Debug.Log("move pressed");
        }
        if (_pressedDownLeft)
        {
            _modelController.GetComponent<ModelController>().RotateFurniture("left");
            Debug.Log("left pressed");
        }
        if (_pressedDownRight)
        {
            _modelController.GetComponent<ModelController>().RotateFurniture("right");
            Debug.Log("right pressed");
        }
    }

    public void OnPressMove()
    {
        _pressedDownMove = true;
    }

    public void OnReleaseMove()
    {
        _pressedDownMove = false;
    }

    public void OnPressLeft()
    {
        _pressedDownLeft = true;
    }

    public void OnReleaseLeft()
    {
        _pressedDownLeft = false;
    }

    public void OnPressRight()
    {
        _pressedDownRight = true;
    }

    public void OnReleaseRight()
    {
        _pressedDownRight = false;
    }
}
