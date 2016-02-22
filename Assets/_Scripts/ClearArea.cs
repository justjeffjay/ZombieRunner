using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

    public bool areaIsClear;

    private float clearTime = 2f;       //seconds of clear before trigger clear area
    private float lastTriggerTime;

	// Use this for initialization
	void Start () {
        lastTriggerTime = Time.time;
        areaIsClear = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!areaIsClear && IsAreaClear() && (Time.timeSinceLevelLoad > 10f)) {     //TODO HACK don't trigger in first 10s
            Debug.Log("Found Clear Area");
            areaIsClear = true;
            SendMessageUpwards("OnFoundClearArea");
        }
	}

    void OnTriggerStay(Collider collider) {
        if (collider.tag != "Player") {
            lastTriggerTime = Time.time;
            //areaIsClear = false;
        }
    }

    bool IsAreaClear() {
        return (Time.time - lastTriggerTime > clearTime);
    }
}
