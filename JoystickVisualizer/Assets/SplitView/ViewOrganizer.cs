using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewOrganizer : MonoBehaviour {
    private const float OFFSET = 20.0f;

    public GameObject NoDevicesText;
    public GameObject[] ControllerModels;
    public GameObject CameraTemplate;

    private List<GameObject> activeControllers = new List<GameObject>();
    private List<GameObject> cameras = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        return;
        if (ControllerModels == null || ControllerModels.Length == 0)
            ControllerModels = GameObject.FindGameObjectsWithTag("ControllerModel").OrderBy(o => o.transform.parent.GetSiblingIndex()).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        return;

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
            if (NoDevicesText != null)
                NoDevicesText.SetActive(activeControllers.Count == 0);

            Debug.Log("Active controller count changed from " + oldLength + " to " + activeControllers.Count + ", reorganizing models");

            switch(activeControllers.Count)
            {
                case 1:
                    ClearCameras();
                    CreateControllerCamAt(new Vector3(100, 100, 0), activeControllers[0]);
                    break;
                case 2:
                    ClearCameras();
                    GameObject cam1 = CreateControllerCamAt(new Vector3(100, 100, 0), activeControllers[0]);
                    GameObject cam2 = CreateControllerCamAt(new Vector3(200, 100, 0), activeControllers[1]);
                    cam1.GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 1);
                    cam2.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
                    break;
                default:
                    ClearCameras();
                    CameraTemplate.SetActive(true);
                    break;
            }
        }
    }

    private void ClearCameras()
    {
        foreach (GameObject camera in cameras)
        {
            camera.SetActive(false);
            Destroy(camera);
        }
        cameras.Clear();
        CameraTemplate.SetActive(false);
    }

    private GameObject CreateControllerCamAt(Vector3 pos, GameObject controller, string name = null)
    {
        GameObject cam = GameObject.Instantiate<GameObject>(CameraTemplate);
        cam.transform.position = pos;
        cam.SetActive(true);

        cam.name = name == null ? "Camera " + pos.ToString() : name;

        cameras.Add(cam);
        controller.transform.position = new Vector3(pos.x, pos.y-7, pos.z + 20);

        return cam;
    }
}
