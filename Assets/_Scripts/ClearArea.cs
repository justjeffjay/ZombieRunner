using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {

    public bool areaIsClear;

    private float clearTime = 2f;       //seconds of clear before trigger clear area
    private float lastTriggerTime;
    private bool calledForHeli = false;

    // Use this for initialization
    void Start () {
        lastTriggerTime = Time.time;
        areaIsClear = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!calledForHeli && !areaIsClear && IsAreaClear() && (Time.timeSinceLevelLoad > 10f)) {     //TODO HACK don't trigger in first 10s
            areaIsClear = true;
            SendMessageUpwards("OnFoundClearArea");                //tell InnerVoice and Player found spot
        }
	}

    bool IsAreaClear() {
        return (Time.time - lastTriggerTime > clearTime);
    }

    void OnTriggerStay(Collider collider) {
        if (collider.tag != "Player") {
            lastTriggerTime = Time.time;
            areaIsClear = false;
        }
    }

    void OnPlayerCalledForHeli() {
        if (areaIsClear && (Time.timeSinceLevelLoad > 10f)) {       //TODO HACK don't trigger in first 10s
            calledForHeli = true;
            Vector3 landingPosition = transform.position;
            landingPosition.y -= 20f;                                               //offset due to larger box collider on cleararea
            SendMessageUpwards("OnMakeInitialHeliCall", landingPosition);
        }
    }
}
