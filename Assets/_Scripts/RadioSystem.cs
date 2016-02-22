using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {

    public AudioClip heliCall;
    public AudioClip heliReply;

    private AudioSource audioSource;
    private Vector3 landingZonePosition;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void OnPlayerCallsForHeli() {
        BroadcastMessage("OnPlayerCalledForHeli");
    }

    void OnMakeHeliCall(Vector3 foundPosition) {
        audioSource.clip = heliCall;
        audioSource.Play();

        landingZonePosition = foundPosition;
        Invoke("CallReply", heliCall.length + 1f);
    }
    void CallReply() {
        audioSource.clip = heliReply;
        audioSource.Play();
        BroadcastMessage("OnDispatchHelicopter", landingZonePosition);      //call helicopter
    }

}
