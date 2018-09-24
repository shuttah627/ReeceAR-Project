﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModelController : MonoBehaviour, IBaseScript
{
    public Transform _groundPlane;
    public GameObject _toilet;
    public GameObject _marker;
    public Camera _arCamera;
    // TESTING ONLY
    public Text _testText;

    [Range(0f, 2f)]
    public float _movementAmount = 0.1f;

    public float _rotateAmount = 20f;

    public float _ButtonPressSelectDisable;

    private GameObject _selectedObject;
    private GameObject _selectedObjectMarker;
    private List<GameObject> _spawnedObjects;
    private bool _shouldBreak;
    private float _markerYPos;

    public List<ScriptableTemplate> _productList = new List<ScriptableTemplate>();

    void Start()
    {
        _spawnedObjects = new List<GameObject>();

        //spawn in marker
        //_selectedObjectMarker = Instantiate(_marker, transform.position, transform.rotation);
        //_selectedObjectMarker.transform.SetParent(_groundPlane);
        //_selectedObjectMarker.SetActive(false); // TESTING THE SCALE ISSUE. TEMPORARY.

        //AddFurnitureToPlane();
        //SpawnProductViaID("2080660");


    }

    void Update()
    {



        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            _testText.text = "Touched"; //for android testing
            //stop selection occuring when ui is pressed
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                //ui pressed do nothing
                Debug.Log("UI pressed");
            }
            else { SelectObjectCheck(); }
        }
        else
        {
            _testText.text = "N/A";
        }
        /*
        //move selcetion marker
        if (_selectedObject != null)
        {

            _selectedObjectMarker.transform.position = new Vector3(_selectedObject.transform.position.x, _markerYPos, _selectedObject.transform.position.z);

            //make maker visible
            //_selectedObjectMarker.SetActive(true);

        }
        */
    }

    public void MoveFurniture(string moveType)
    {
        Vector3 _tempVec = new Vector3(0, 0, 0);
        // foreach (GameObject x in _spawnedObjects)
        // {
        switch (moveType)
        {

            case "point":
                _selectedObject.GetComponent<Transform>().position = GameObject.Find("DefaultPlaneIndicator - Copy(Clone)").GetComponent<Transform>().localPosition;
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
        _selectedObject.GetComponent<Transform>().localPosition += _tempVec;
        // }
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
            _selectedObject.GetComponent<Transform>().Rotate(_tempVec, _rotateAmount);
        }
    }

    public void SpawnProductViaID(string id)
    {
        foreach (ScriptableTemplate x in _productList)
        {
            if (x._productCode == id)
            {
                GameObject y = Instantiate(x._productModel, transform.position, transform.rotation);
                y.transform.SetParent(_groundPlane);
                y.transform.localScale = x._productScale;
                _spawnedObjects.Add(y);
                _selectedObject = y;

                //add collider to the object for the selection system and resize it
                _selectedObject.AddComponent<BoxCollider>();
                BoxCollider m_Collider = _selectedObject.GetComponent<BoxCollider>();
                m_Collider.size = new Vector3(70, 70, 70);

                //position marker
                //_markerYPos = PositionMarker();

                return;
            }
        }
    }

    public float PositionMarker()
    {
        //set new object as parent of marker
        _selectedObjectMarker.transform.SetParent(_selectedObject.transform);

        //move marker parent
        _selectedObjectMarker.transform.position = new Vector3(0.0f, 0.0f, 0.0f) ;

        //find lowest point of any child ---- not ideal needs more work as it is the middle of the lowest child
        float lowest = Mathf.Infinity;
        for (int i = 0; i < _selectedObject.transform.childCount; i++)
        {
            Transform temp = _selectedObject.transform.GetChild(i);
            Mesh mesh = temp.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            int x = 0;
            while (x < vertices.Length)
            {
                if (vertices[x].y < lowest) lowest = vertices[x].y;
                x++;
            }

        }

        //get values for main object
        float xmin = 0.0f;
        float xmax = 0.0f;
        float zmin = 0.0f;
        float zmax = 0.0f;
        for (int i = 0; i < _selectedObject.transform.childCount; i++)
        {
            Transform temp = _selectedObject.transform.GetChild(i);
            Mesh mesh = temp.GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            int x = 0;
            while (x < vertices.Length)
            {
                if (vertices[x].x < xmin) xmin = vertices[x].x; //xmin
                if (vertices[x].z < zmin) zmin = vertices[x].z; //zmin
                if (vertices[x].x > xmax) xmax = vertices[x].x; //xmax
                if (vertices[x].z > zmax) zmax = vertices[x].z; //zmax
                x++;
            }

        }
        /*
        //scale marker ---- probably a better way to do this
        bool breakx = true;
        while (breakx)
        {
            
            float mxmin = 0.0f;
            float mxmax = 0.0f;
            float mzmin = 0.0f;
            float mzmax = 0.0f;
            
            //  ------------- currently something in this breaks the location of the marker ----------------
            for (int i = 1; i < _selectedObjectMarker.transform.childCount; i++)
            {
                
                Transform temp = _selectedObjectMarker.transform.GetChild(i);
                Mesh mesh = temp.GetComponent<MeshFilter>().mesh;
                Vector3[] vertices = mesh.vertices;
                int x = 0;
                while (x < vertices.Length)
                {
                    if (vertices[x].x < mxmin) mxmin = vertices[x].x; //xmin
                    if (vertices[x].z < mzmin) mzmin = vertices[x].z; //zmin
                    if (vertices[x].x > mxmax) mxmax = vertices[x].x; //xmax
                    if (vertices[x].z > mzmax) mzmax = vertices[x].z; //zmax
                    x++;
                }
                
            }
           
            
            //check if scaled high enough
            if (mxmax >= xmax || mzmax >= zmax || mxmin <= xmin || mzmin <= zmin)
            { breakx = false; }
            //scale more
            else
            {
                _selectedObjectMarker.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            }
            
        }
        */


        //move marker to calculated point
        Vector3 _currentpos;
        _currentpos = _selectedObjectMarker.transform.position;
        _selectedObjectMarker.transform.position = new Vector3(_currentpos.x, lowest, _currentpos.z);

        //remove this when dynamic scaling is done
        //_selectedObjectMarker.transform.localScale = new Vector3 (30,30,30);

        return lowest;

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
        //set our current object as the one just spawned
        _selectedObject = x;

        //add collider to the object for the selection system and resize it
        _selectedObject.AddComponent<BoxCollider>();
        BoxCollider m_Collider = _selectedObject.GetComponent<BoxCollider>();
        m_Collider.size = new Vector3(70, 70, 70);

        //positon the marker


       _markerYPos = PositionMarker();


    }

    public void RemoveSelectedObject()
    {

        //loop through spawned list and delete object entry
        for (int x = 0; x < _spawnedObjects.Count; x++)
        {
            if (_selectedObject == _spawnedObjects[x])
            {
                _spawnedObjects.Remove(_selectedObject);
            }
        }

        //remove object from scene
        Destroy(_selectedObject);

        //select another object from the list
        for (int x = 0; x < _spawnedObjects.Count; x++)
        {
            if (_spawnedObjects[x] != null)
            {
                _selectedObject = _spawnedObjects[x];
            }
        }

    }

    void SelectObjectCheck()
    {
        //checks if the first touch is pointing at an object
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            //if trying to select an object check the object is in the list
            for (int x = 0; x < _spawnedObjects.Count; x++)
            {
                if (hit.transform.gameObject == _spawnedObjects[x])
                {
                    //make the currently selected object the one that was hit
                    _selectedObject = hit.transform.gameObject;

                    //move selection marker
                    //_markerYPos = PositionMarker();

                }
            }






        }

    }


}
