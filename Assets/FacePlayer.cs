using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
    public Camera playerFocus;
    // Start is called before the first frame update
    void Start() {
        playerFocus = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.LookAt(playerFocus.transform);
        transform.rotation = Quaternion.LookRotation(playerFocus.transform.forward);
    }
}
