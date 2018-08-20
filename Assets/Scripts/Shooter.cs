﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    private void Start() {
        projectileParent = GameObject.Find("Projectiles");
        animator = GetComponent<Animator>();
        
        if (!projectileParent) {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    private void Update() {
        if (isAttackerAheadInLane()) {
            animator.SetBool("isAttacking", true);
        }
        else {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetMyLaneSpawner() {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray) {
            if(spawner.transform.position.y == this.transform.position.y) {
                myLaneSpawner = spawner;
                return;
            }
        }
        Debug.LogError(name + "can't find spawner in lane");

    }


    private bool isAttackerAheadInLane() {
        // Exit if no attackers in lane
        if(myLaneSpawner.transform.childCount <= 0) {
            return false;
        }

        // If there are attackers, are they ahead ?
        foreach(Transform attacker in myLaneSpawner.transform) {
            if(attacker.transform.position.x > transform.position.x) {
                return true;
            }
        }

        // Attacker in lane, but behind us
        return false;
    }

    private void Fire() {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

}
