using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {    
    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start () {
        this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget) {
            animator.SetBool("isAttackingTrigger", false);
        }
	}

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(name + "trigger entered");
    }

    public void setSpeed(float speed) {
        this.currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage) {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health) {
                health.DealDamage(damage);
            }
        }        
    }


    public void Attack(GameObject obj) {
        this.currentTarget = obj;
    }
}
