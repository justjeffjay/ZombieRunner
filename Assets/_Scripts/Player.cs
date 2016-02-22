using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool respawnActive = false;
    public GameObject landingZonePrefab;

    private Transform[] spawnPoints;
    private Vector3 landingZonePosition;

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

    void OnFoundClearArea() {
        Debug.Log("Clear area found by " + name);
        landingZonePosition = transform.position;           //save position immediately in case player keeps moving
        Invoke("DropFlare", 3f);
    }
    void DropFlare() {
        Debug.Log("Deploy flare");
        Instantiate(landingZonePrefab, landingZonePosition, Quaternion.identity);
    }           

}
