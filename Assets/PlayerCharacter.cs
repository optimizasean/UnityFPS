using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
    private int _health;

    // Start is called before the first frame update
    void Start() {
        _health = 5;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Hurt(int damage) {
        _health -= damage;
        Debug.Log("Health: " + _health);
    }
}
