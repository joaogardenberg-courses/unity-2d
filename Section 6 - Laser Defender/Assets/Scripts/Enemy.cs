using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("Enemy Stats")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [Header("Shooting")]
    [SerializeField] float minTimeBewtweenShots = 0.2f;
    [SerializeField] float maxTimeBewtweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [Header("Visual Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [Header("Sound Effects")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.7f;
    [SerializeField] AudioClip projectileSFX;
    [SerializeField] [Range(0, 1)] float projectileSFXVolume = 0.1f;


    float shotCounter;

    void Start() {
        shotCounter = Random.Range(minTimeBewtweenShots, maxTimeBewtweenShots);
    }

    void Update() {
        CountDownAndShoot();
    }

    private void CountDownAndShoot() {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f) {
            Fire();
            shotCounter = Random.Range(minTimeBewtweenShots, maxTimeBewtweenShots);
        }
    }

    private void Fire() {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
        ) as GameObject;

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileSFXVolume);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (damageDealer) {
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer) {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        Destroy(explosion, durationOfExplosion);
    }
}
