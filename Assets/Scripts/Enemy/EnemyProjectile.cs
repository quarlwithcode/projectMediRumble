using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	private int damage = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff = GetComponent<Rigidbody2D>().velocity;
		diff.Normalize ();
		print (diff);

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Castle") {
			other.gameObject.GetComponent<CastleHealthController> ().Damage (damage);
			Destroy (transform.parent.gameObject);
		}
	}

	public void SetDamage(int d){
		damage = d;
	}
}
