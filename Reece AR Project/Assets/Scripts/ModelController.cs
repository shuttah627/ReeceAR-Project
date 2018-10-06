using System.Collections;
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
        _selectedObjectMarker = Instantiate(_marker, transform.position, transform.rotation);
        _selectedObjectMarker.transform.SetParent(_groundPlane);
        _selectedObjectMarker.SetActive(true);

        //AddFurnitureToPlane();
        //SpawnProductViaID("2080660");


    }

    void Update()
    {

        //Debug.Log("update detected");

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            Debug.Log("touch detected");
            _testText.text = "Touched"; //for android testing
            //stop selection occuring when ui is pressed
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && EventSystem.current.CompareTag("selectionIgnore") != true)
            {
                //ui pressed do nothing
                Debug.Log("pressed: " + EventSystem.current.CompareTag("selectionIgnore"));
                Debug.Log("UI pressed");
            }
            else { SelectObjectCheck(); Debug.Log("entering check"); }
        }
        //check if mouse input
        else if(Input.GetMouseButtonDown(0) )
        {
            Debug.Log("touch detected");
            _testText.text = "Touched"; //for android testing
            //stop selection occuring when ui is pressed
            if (EventSystem.current.IsPointerOverGameObject() && EventSystem.current.CompareTag("selectionIgnore") != true)
            {
                //ui pressed do nothing
                Debug.Log("pressed: " + EventSystem.current.name );
                Debug.Log("UI pressed");
            }
            else { SelectObjectCheckMouse(); Debug.Log("entering check"); }
        }
        else
        {
            _testText.text = "N/A";
        }
        
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

                //position the marker
                PositionMarker();
                

                return;
            }
        }
    }

    public void MoveMarkerOffScreen()
    {
        _selectedObjectMarker.transform.SetParent(_groundPlane);
        _selectedObjectMarker.transform.position = new Vector3(99, 99, 99);
    }

    public void PositionMarker()
    {
        if (_selectedObject != null)
        {
            //set new object as parent of marker
            _selectedObjectMarker.transform.SetParent(_selectedObject.transform);

            //move marker parent
            _selectedObjectMarker.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);

            //get collider and lowest point
            Collider m_Collider = _selectedObject.GetComponent<BoxCollider>();
            float lowest = m_Collider.bounds.min.y;

            //move marker to calculated point
            Vector3 _currentpos;
            _currentpos = _selectedObjectMarker.transform.position;
            _selectedObjectMarker.transform.localPosition = new Vector3(_currentpos.x, lowest, _currentpos.z);
        }
        //if no selcted object move marker away
        else { MoveMarkerOffScreen(); }

        

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


       //positon the marker
       PositionMarker();


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

        //make a temp pointer for the old selected object, this prevents the marker acidently being deleted
        GameObject _toDel = _selectedObject;

        _selectedObject = null;

        //select another object from the list, if none avalible set null
        for (int x = 0; x < _spawnedObjects.Count; x++)
        {
            if (_spawnedObjects[x] != null)
            {
                _selectedObject = _spawnedObjects[x];
            }
            
        }

        //move the marker
        PositionMarker();

        //remove object from scene
        Destroy(_toDel);

    }

    void SelectObjectCheck()
    {
        //move marker off screen incase no object is selected
        MoveMarkerOffScreen();

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
                    PositionMarker();

                }
                else { MoveMarkerOffScreen(); }
            }
            
        }
        else { MoveMarkerOffScreen(); }

    }

    //same function as above but handles mouse inputs (for testing in unity)
    void SelectObjectCheckMouse()
    {
        //move marker off screen incase no object is selected
        MoveMarkerOffScreen();

        //checks if the first touch is pointing at an object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
                    PositionMarker();

                }
            }
        }

    }

}
