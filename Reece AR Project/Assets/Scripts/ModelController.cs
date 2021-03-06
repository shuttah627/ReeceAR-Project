﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour, IBaseScript {
    public Transform _groundPlane;
    public GameObject _toilet;
    public Camera _arCamera;

    [Range(0f, 2f)]
    public float _movementAmount = 0.1f;

    public float _rotateAmount = 20f;

    private GameObject _selectedObject;
    private List<GameObject> _spawnedObjects;
    private bool _shouldBreak;

    void Start () {
        _spawnedObjects = new List<GameObject>();
        AddFurnitureToPlane();
	}
    /*
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("We touched the screen!");
            RaycastHit hit;
            Ray x = _arCamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(x, out hit)) {
                Debug.Log(hit.transform.parent.name);
            }
        }
    }*/

    public void MoveFurniture(string moveType)
    {
        Vector3 _tempVec = new Vector3(0, 0, 0);
        foreach (GameObject x in _spawnedObjects)
        {
            switch (moveType)
            {
                case "point":
                    x.GetComponent<Transform>().localPosition = GameObject.Find("DefaultPlaneIndicator(Clone)").GetComponent<Transform>().localPosition;
                    break;
                case "forward":
                    _tempVec = new Vector3(0f, 0f, -_movementAmount);
                    break;
                case "back":
                    _tempVec = new Vector3(0f, 0f, _movementAmount);
                    break;
                case "left":
                    _tempVec = new Vector3(-_movementAmount, 0f, 0f);
                    break;
                case "right":
                    _tempVec = new Vector3(_movementAmount, 0f, 0f);
                    break;
            }
            x.GetComponent<Transform>().localPosition += _tempVec;
        }
    }

    public void RotateFurniture(string rotType)
    {
        Vector3 _tempVec = new Vector3(0, 0, 0);
        foreach (GameObject x in _spawnedObjects)
        {
            switch (rotType)
            {
                case "left":
                    _tempVec = new Vector3(0f, -1f, 0f);
                    break;
                case "right":
                    _tempVec = new Vector3(0f, 1f, 0f);
                    break;
            }
            x.GetComponent<Transform>().Rotate(_tempVec, _rotateAmount);
        }
    }
    
    public void AddFurnitureToPlane()
    {
        // TO DO: Add ScriptableObject to the arguments.

        // I have no idea how we are going to handle this yet. Need further development.
        // Need to add model gameObject as a child of _groundPlane
        // Can refer to the list of children. expensive vs holding a list.
        // holding a list also has its issues. Deleting furniture is one of them.
        // Will discuss with team.

        /* Test Script
        for (int i = 0; i < 10; i++)
        {
            GameObject x = new GameObject("TestObjFurniture");
            _spawnedObjects.Add(x);
            x.transform.SetParent(_groundPlane);
        }
        */

        GameObject x = Instantiate(_toilet, transform.position, transform.rotation);
        x.transform.SetParent(_groundPlane);
        _spawnedObjects.Add(x);
        

    }
}
