using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
    [SerializeField] [Range(0f, 5f)] float defaultSpeed = 1f;
    [Range(0f, 5f)] float currentSpeed = 1f;

    void Start() {
        currentSpeed = defaultSpeed;
    }

    void Update() {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }
}
