using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D otherCollider) {
        FindObjectOfType<LivesDisplay>().TakeLife();
        Destroy(otherCollider.gameObject);
    }
}
