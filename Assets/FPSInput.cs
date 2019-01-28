using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    private CharacterController _cCntrl;
    public float speed = 6.0f;
    public float grav = -9.8f;

    // Start is called before the first frame update
    void Start() {
        _cCntrl = GetComponent <CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 mov = new Vector3(deltaX, 0, deltaZ);
        mov = Vector3.ClampMagnitude(mov, speed);
        mov.y = grav;

        mov *= Time.deltaTime;
        mov = transform.TransformDirection(mov);
        _cCntrl.Move(mov);
    }
}
