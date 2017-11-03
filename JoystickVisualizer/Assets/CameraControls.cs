using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

    public GameObject Camera;

    public GameObject Target;
    private float speedMod = 100.0f;
    private Vector3 point;

                          // Use this for initialization
    void Start () {
        point = Target.transform.GetComponent<Renderer>().bounds.center;
        Camera.transform.LookAt(point);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Camera Down"))
        {
            Camera.transform.Rotate(Vector3.left * Time.deltaTime * speedMod, Space.Self);
        }
        if (Input.GetButton("Camera Up"))
        {
            Camera.transform.Rotate(Vector3.right * Time.deltaTime * speedMod, Space.Self);
        }

        if (Input.GetButton("Camera Left"))
        {
            Camera.transform.Rotate(Vector3.up * Time.deltaTime * speedMod, Space.World);
        }
        if (Input.GetButton("Camera Right"))
        {
            Camera.transform.Rotate(Vector3.down * Time.deltaTime * speedMod, Space.World);
        }
        if (Input.GetButton("Camera Reset"))
        {
            Camera.transform.rotation = Quaternion.identity;
        }
    }
}
