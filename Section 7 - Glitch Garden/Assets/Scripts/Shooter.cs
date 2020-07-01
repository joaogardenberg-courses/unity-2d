using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner laneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    void Start() {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update() {
        if (IsAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner() {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners) {
            bool IsCloseEnough = Mathf.Abs(
                spawner.transform.position.y - transform.position.y
            ) <= Mathf.Epsilon;

            if (IsCloseEnough) {
                laneSpawner = spawner;
                break;
            }
        }
    }

    private bool IsAttackerInLane() {
        return laneSpawner.transform.childCount > 0;
    }

    public void Fire() {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }
}
