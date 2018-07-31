using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

    [Range (-1f, 1.5f)]
    public float walkSpeed;

	// Use this for initialization
	void Start () {
        Rigidbody2D rigidbody2D = this.gameObject.AddComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
	}
}
