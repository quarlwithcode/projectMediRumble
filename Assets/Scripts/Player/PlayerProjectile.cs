using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	public int damage;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyHealthController> ().Damage (damage);
		}
	}
}
