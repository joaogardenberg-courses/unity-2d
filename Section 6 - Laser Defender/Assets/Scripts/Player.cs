using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Configuration parameters
    [Header("Player")]
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] int health = 200;
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    [SerializeField] GameObject laserPrefab;

    // Global variables
    float minX, minY, maxX, maxY;
    Coroutine firingCoroutine;

    // Global cache variables
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetUpMoveBoundaries();
    }

    void Update() {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) {
            return;
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    private void SetUpMoveBoundaries() {
        Camera gameCamera = Camera.main;
        float spriteXSize = spriteRenderer.bounds.extents.x;
        float spriteYSize = spriteRenderer.bounds.extents.y;

        Vector2 worldPoint = gameCamera.ViewportToWorldPoint(new Vector2(0, 0));
        minX = worldPoint.x + spriteXSize;
        minY = worldPoint.y + spriteYSize;

        worldPoint = gameCamera.ViewportToWorldPoint(new Vector2(1, 0));
        maxX = worldPoint.x - spriteXSize;

        worldPoint = gameCamera.ViewportToWorldPoint(new Vector2(0, 1));
        maxY = worldPoint.y - spriteYSize;
    }

    private void Move() {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        float newX = transform.position.x + deltaX;
        float newY = transform.position.y + deltaY;

        transform.position = new Vector2(Mathf.Clamp(newX, minX, maxX), Mathf.Clamp(newY, minY, maxY));
    }

    private void Fire() {
        if (Input.GetButtonDown("Fire1")) {
            if (firingCoroutine != null) {
                StopCoroutine(firingCoroutine);
            }

            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously() {
        while (true) {
            GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity
            ) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
