using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


	public int attackDamage;
	public float attackRange;
	public float attackRate;
	public bool inRange;

	private GameObject target;


	// Use this for initialization
	void Start () {
		inRange = false;
		target = GameObject.FindGameObjectWithTag ("Castle");

		InvokeRepeating ("CheckRange", 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		


	}


	void CheckRange(){
		print ("Checking... ");
		if (Vector3.Distance (transform.position, target.transform.position) <= attackRange) {
			print ("In Range");
			inRange = true;
			InvokeRepeating ("AutoAttack", 0f, attackRate);
			CancelInvoke ("CheckRange");
		}
	}

	void AutoAttack(){
		print ("shot");
		Vector2 rayOrigin = new Vector2 (transform.position.x + .51f, transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right);
		if (inRange) {
			if (hit.transform.tag == "Castle") {
				print ("Hit");
				HealthController castleHealth = hit.transform.gameObject.GetComponent<HealthController> ();
				castleHealth.Damage (attackDamage);
			}
		}
	}
}
