using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	public float xSpeed;
	public float ySpeed;

	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(transform.localScale.x+xSpeed*Time.deltaTime, transform.localScale.y+ySpeed*Time.deltaTime, transform.localScale.z);

		if (transform.localScale.x > 3) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.GetComponent<EnemyHealthController> ().Damage (damage);
		}
	}
}
