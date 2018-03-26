using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour {

    float rotSpeed = 20;

    void Start()
    {
        Debug.Log("Mouse Rotate " + gameObject.name);
    }

	void OnMouseDrag()
    {
        Debug.Log("Dragged " + gameObject.name);
    }
}
