using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

    private Camera eyes;
    private float defaultFOV;
    private float zoomLevel;

	// Use this for initialization
	void Start () {
        eyes = GetComponent<Camera>();
        defaultFOV = eyes.fieldOfView;
        zoomLevel = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("ViewZoom")) {
            ZoomIn();
        }
        else {
            ZoomStandard();
        }
    }

    private void ZoomIn() {
        eyes.fieldOfView = defaultFOV / zoomLevel;
    }
    private void ZoomStandard() {
        eyes.fieldOfView = defaultFOV;
    }

}
