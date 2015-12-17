using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIEvents : MonoBehaviour {
    private bool uiVisible = true;
    public GameObject buttonContainer;

	void Start () {
	}
	
	void Update () {
        if(Input.GetButtonDown("GUI Toggle"))
        {
            uiVisible = !uiVisible;
            foreach (Button button in buttonContainer.GetComponentsInChildren<Button>(true) )
            {
                button.gameObject.SetActive(uiVisible);
            }
        }
	}
}
