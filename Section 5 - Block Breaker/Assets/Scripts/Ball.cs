using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;
    AudioSource audioSource;
    Rigidbody2D rigidbody2D;

    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (!hasStarted) {
            LaunchOnMouseClick();
            LockToPaddle();
        }
    }


    private void LaunchOnMouseClick() {
        if (Input.GetMouseButtonDown(0)) {
            hasStarted = true;
            rigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockToPaddle() {
        transform.position = (Vector2) paddle1.transform.position + paddleToBallVector;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted) {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
            audioSource.PlayOneShot(clip);
            rigidbody2D.velocity += velocityTweak;
        }
    }
}
