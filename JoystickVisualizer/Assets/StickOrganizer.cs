using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickOrganizer : MonoBehaviour {

    public List<GameObject> Sticks = new List<GameObject>();

	// Use this for initialization
	void Start () {
        foreach (GameObject stick in Sticks)
        {
            stick.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
