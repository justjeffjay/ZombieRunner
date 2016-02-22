using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip clearArea;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
	}
	
    void OnFoundClearArea() {
        Debug.Log("Clear area found by " + name);
        audioSource.clip = clearArea;
        audioSource.Play();

        Invoke("CallHeli", clearArea.length + 1f);
    }
    void CallHeli() {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }

}
