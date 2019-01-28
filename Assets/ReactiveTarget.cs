using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

    private IEnumerator Die() {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

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
