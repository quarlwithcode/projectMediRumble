using UnityEngine;
using System.Collections;

public class ScatterFragmentHealthController : HealthController {


	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			Damage(1);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			Destroy (this.gameObject);
		}
	}
}
