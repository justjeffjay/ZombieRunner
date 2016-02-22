using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

    public float heliSpeed = 50f;

    private bool isCalled;
    private Rigidbody myRigidbody;
    private Vector3 landingZonePosition;        //landing area above spot on ground to fly to
    private Vector3 landingZoneGround;          //landing spot on ground

    // Use this for initialization
    void Start () {
        isCalled = false;
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isCalled && Input.GetButtonDown("CallHeli")) {
            SendMessageUpwards("OnPlayerCallsForHeli");
        }
        if (isCalled && transform.position.z > -1500) {
            RedirectHeli();
        }
    }

    //TODO starting point to move helicopter to a specific spot
    void RedirectHeli() {
        myRigidbody.velocity = new Vector3(0f, 0f, 0f);     //stop velocity as will control from script from here
        transform.position = Vector3.MoveTowards(transform.position, landingZonePosition, heliSpeed * Time.deltaTime);
        if (transform.position == landingZonePosition) {
            landingZonePosition = landingZoneGround;        //once reach landing zone position above ground, lower to ground
        }
    }

    public void OnDispatchHelicopter(Vector3 foundPostion) {
        if (!isCalled) {
            isCalled = true;
            landingZonePosition = landingZoneGround = foundPostion;
            landingZonePosition.y = transform.position.y;                        //keep heli's height
            myRigidbody.velocity += new Vector3(0f, 0f, heliSpeed);              //50 m/s at 9000 m away = 3 min    
        }  
    }

}
