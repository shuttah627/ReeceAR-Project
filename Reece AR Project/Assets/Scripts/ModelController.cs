using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour, IBaseScript {
    public Transform _groundPlane;
    private List<GameObject> _spawnedObjects;

	// Use this for initialization
	void Start () {
        _spawnedObjects = new List<GameObject>();
        AddFurnitureToPlane();
	}
	
	// Update is called once per frame
	void Update () {
		
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

        GameObject x = new GameObject("TestObjFurniture");
        x.transform.SetParent(_groundPlane);
        _spawnedObjects.Add(x);
        

    }
}
