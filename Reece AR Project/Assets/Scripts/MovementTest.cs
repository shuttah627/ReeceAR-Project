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
}
