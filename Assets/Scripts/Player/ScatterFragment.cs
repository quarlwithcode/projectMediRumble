using UnityEngine;
using System.Collections;

public class ScatterFragment : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff = GetComponent<Rigidbody2D>().velocity;
		diff.Normalize ();
		//print (diff);

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthController> ().Damage (damage);
		}
	}
}
