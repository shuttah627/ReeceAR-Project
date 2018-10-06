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
        }
        if (_pressedDownLeft)
        {
            _modelController.GetComponent<ModelController>().RotateFurniture("left");
        }
        if (_pressedDownRight)
        {
            _modelController.GetComponent<ModelController>().RotateFurniture("right");
        }
    }

    public void StopSelectionSystem()
    {
        _modelController.GetComponent<ModelController>()._UiButtonPressed = true;
    }
    public void StartSelectionSystem()
    {
        _modelController.GetComponent<ModelController>()._UiButtonPressed = false;
    }

    public void OnPressMove()
    {
        _pressedDownMove = true;
        StopSelectionSystem();
    }

    public void OnReleaseMove()
    {
        _pressedDownMove = false;
        StartSelectionSystem();
    }

    public void OnPressLeft()
    {
        _pressedDownLeft = true;
        StopSelectionSystem();
    }

    public void OnReleaseLeft()
    {
        _pressedDownLeft = false;
        StartSelectionSystem();

    }

    public void OnPressRight()
    {
        _pressedDownRight = true;
        StopSelectionSystem();
    }

    public void OnReleaseRight()
    {
        _pressedDownRight = false;
        StartSelectionSystem();
    }
}
