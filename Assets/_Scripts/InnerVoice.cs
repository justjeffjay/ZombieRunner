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
        audioSource.clip = clearArea;
        audioSource.Play();
    }

}
