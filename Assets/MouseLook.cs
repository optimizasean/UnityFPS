using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public float sensitivityHorz = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float _rotX = 0;

    public enum RotationAxes {
        MouseXY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXY;

    // Start is called before the first frame update
    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        if (axes == RotationAxes.MouseX) {
            //Horizontal
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorz, 0);
        } else if (axes == RotationAxes.MouseY) {
            //Vertical
            _rotX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotX = Mathf.Clamp(_rotX, minVert, maxVert);

            float rotY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotX, rotY, 0);
        } else {
            //Both
            _rotX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotX = Mathf.Clamp(_rotX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivityHorz;
            float rotY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotX, rotY, 0);
        }
    }
}
