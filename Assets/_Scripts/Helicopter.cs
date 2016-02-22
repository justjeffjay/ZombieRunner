using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {

    private bool isCalled;
    private Rigidbody myRigidbody;

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

    public void OnDispatchHelicopter() {
        if (!isCalled) {
            isCalled = true;
            myRigidbody.velocity += new Vector3(0f, 0f, 50f);       //50 m/s at 9000 m away = 3 min    
        }  
    }
}
