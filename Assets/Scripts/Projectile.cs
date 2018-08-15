using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Speed;
    public float Damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.right * Speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();

        if(attacker && health) {
            health.DealDamage(Damage);
            Destroy(this.gameObject);
        }

    }

}
