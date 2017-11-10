using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StickOrganizer : MonoBehaviour {
    private const float OFFSET = 20.0f;

    public GameObject NoDevicesText;
    public GameObject[] ControllerModels;

    private List<GameObject> activeControllers = new List<GameObject>();
    
    // Use this for initialization
    void Start () {
        if (ControllerModels == null || ControllerModels.Length == 0)
            ControllerModels = GameObject.FindGameObjectsWithTag("ControllerModel").OrderBy(o => o.transform.parent.GetSiblingIndex()).ToArray();
    }
	
	// Update is called once per frame
	void Update () {
        if (ControllerModels == null)
            return;

        int oldLength = activeControllers.Count;

        activeControllers.Clear();

        foreach (GameObject model in ControllerModels)
        {
            if (model.activeInHierarchy)
                activeControllers.Add(model);
        }

        if (oldLength != activeControllers.Count)
        {
            NoDevicesText.SetActive(activeControllers.Count == 0);

            Debug.Log("Active controller count changed from "+ oldLength + " to " + activeControllers.Count + ", reorganizing models");
            
            float center = ((activeControllers.Count-1) * OFFSET) / 2;

            for (int i=0; i < activeControllers.Count; i++)
            {
                activeControllers[i].transform.position = new Vector3((i * OFFSET) - center, activeControllers[i].transform.position.y, activeControllers[i].transform.position.z);
            }
        }
    }
}
