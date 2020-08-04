using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] float movementSpeed = 1f;
    Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        rigidBody.velocity = new Vector2(IsFacingRight() ? movementSpeed : -movementSpeed, rigidBody.velocity.y);
    }

    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    void OnTriggerExit2D(Collider2D collision) {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidBody.velocity.x)), 1f);
    }
}
