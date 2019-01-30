using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
    public Vector3 _rotation = new Vector3(-75, 0, 0);
    public int _rotations = 5;
    public float _deathspeed = 1.5f;

    private IEnumerator Die() {
        float x = _rotation.x / _rotations;
        float y = _rotation.y / _rotations;
        float z = _rotation.z / _rotations;
        float d = _deathspeed / _rotations;

        for (int i = 0; i < _rotations; i++) {
            this.transform.Rotate(x, y, z);

            yield return new WaitForSeconds(d);
        }
        

        Destroy(this.gameObject);
    }

    public void ReactToHit() {
        WanderingAI behaviour = GetComponent<WanderingAI>();
        if (behaviour != null) {
            behaviour.setAlive(false);
        }
        StartCoroutine(Die());
    }
}
