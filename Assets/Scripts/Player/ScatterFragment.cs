using UnityEngine;
using System.Collections;

public class ScatterFragment : MonoBehaviour {

	public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			other.gameObject.GetComponent<EnemyHealthController> ().Damage (damage);
		}
	}
}
