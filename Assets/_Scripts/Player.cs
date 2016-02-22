using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool respawnActive = false;
    public GameObject landingZonePrefab;

    private Transform[] spawnPoints;

    // Use this for initialization
    void Start() {
        spawnPoints = GameObject.Find("PlayerSpawnPoints").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update() {
        if (respawnActive) {
            Respawn();
        }
    }

    void Respawn() {
        int whichPoint = Random.Range(1, spawnPoints.Length);       //element 0 is parent's transform
        transform.position = spawnPoints[whichPoint].position;
        respawnActive = false;
    }

    void OnMakeInitialHeliCall(Vector3 foundPosition) {
        DropFlare(foundPosition);
        SendMessageUpwards("OnMakeHeliCall", foundPosition);      //call radio for Heli
    }
    void DropFlare(Vector3 foundPosition) {
        Instantiate(landingZonePrefab, foundPosition, Quaternion.identity);
    }

}
