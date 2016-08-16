using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	public int damage;

	protected Resetter bounds;
	protected ProjectileDragging pDragging;

	protected virtual void Start(){
		bounds = GameObject.FindGameObjectWithTag ("Bounds").GetComponent<Resetter> ();
		pDragging = GetComponent<ProjectileDragging> ();
	}

	protected virtual void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyHealthController> ().Damage (damage);
		}
	}
}
