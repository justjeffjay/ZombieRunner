using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {

    public AudioClip heliCall;
    public AudioClip heliReply;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
    void OnMakeInitialHeliCall() {
        audioSource.clip = heliCall;
        audioSource.Play();

        Invoke("CallReply", heliCall.length + 1f);
    }
    void CallReply() {
        audioSource.clip = heliReply;
        audioSource.Play();
        BroadcastMessage("OnDispatchHelicopter");
    }

}
