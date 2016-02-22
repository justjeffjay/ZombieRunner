using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

    private bool isCalled;
    private Rigidbody myRigidbody;
    private Vector3 landingZonePosition;

    // Use this for initialization
    void Start () {
        isCalled = false;
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isCalled && Input.GetButtonDown("CallHeli")) {
            //OnDispatchHelicopter();
        }
    }

    public void OnDispatchHelicopter(Vector3 foundPostion) {
        if (!isCalled) {
            isCalled = true;
            landingZonePosition = foundPostion;
            Debug.Log("Helicopter dispatched to: " + landingZonePosition);
            myRigidbody.velocity += new Vector3(0f, 0f, 50f);       //50 m/s at 9000 m away = 3 min    
        }  
    }

    //TODO starting point to move helicopter to a specific spot
    void RedirectHeli(Vector3 foundPosition) {
        float speed = 50f;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, foundPosition, step);
    }
}
