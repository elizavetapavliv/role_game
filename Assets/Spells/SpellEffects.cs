using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellEffects : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	[SerializeField]
	private float speed;
	public Transform MyTarget { get; set; }

	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate(){
		if (MyTarget != null) {
			Vector2 direction = MyTarget.position - transform.position;
			myRigidBody.velocity = direction.normalized * speed;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.tag == "Enemy") {
			myRigidBody.velocity = Vector2.zero;
			MyTarget = null;
		}
	}
}
