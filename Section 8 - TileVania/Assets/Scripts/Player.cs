using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Config
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] float climbSpeed = 7f;

    // State
    bool isAlive = true;

    // Cached component references
    Rigidbody2D rigidbody;
    Animator animator;
    Collider2D collider;
    float startGravityScale;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        startGravityScale = rigidbody.gravityScale;
    }

    void Update() {
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
    }

    private void Run() {
        // Horizontal axis is between -1 and +1
        rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rigidbody.velocity.y);
        animator.SetBool("isRunning", Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon);
    }

    private void Jump() {
        if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return;
        }

        if (Input.GetButtonDown("Jump")) {
            rigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    private void FlipSprite() {
        if (Mathf.Abs(rigidbody.velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody.velocity.x), 1f);
        }
    }

    private void ClimbLadder() {
        if (!collider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            animator.SetBool("isClimbing", false);
            rigidbody.gravityScale = startGravityScale;
            return;
        }

        // Vertical axis is between -1 and +1
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, Input.GetAxis("Vertical") * climbSpeed);
        rigidbody.gravityScale = 0;
        animator.SetBool("isClimbing", Mathf.Abs(rigidbody.velocity.y) > Mathf.Epsilon);
    }
}
