using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator animator;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision) {        
        GameObject objCollided = collision.gameObject;

        if (!objCollided.GetComponent<Defender>()) {
            return;
        }

        if (objCollided.GetComponent<Stone>()) {
            animator.SetTrigger("JumpTrigger");
        }else {
            animator.SetBool("isAttackingTrigger", true);
            attacker.Attack(objCollided);
        }        
    }

}
