using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


	public int attackDamage;
	public float attackRange;
	public float attackRate;
	public Transform target;
	public bool inRange;
	public LayerMask attackLayer;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Castle").GetComponent<Transform>();

		inRange = false;

		InvokeRepeating ("CheckRange", 0f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		


	}


	void CheckRange(){
		//print (transform.position.x + "vs" + target.position.x);

		if (Vector3.Distance (transform.position, target.position) <= attackRange) {
			//print ("In Range");
			inRange = true;
			InvokeRepeating ("AutoAttack", 0f, attackRate);
			CancelInvoke ("CheckRange");
		}
	}

	void AutoAttack(){
		//print ("attack");
		Vector2 rayOrigin = new Vector2 (transform.position.x + .51f, transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, 50f, attackLayer);
		if (inRange) {
			//print (hit.transform.name);
			if (hit.transform.tag == "Castle") {
				//print ("Hit");
				HealthController castleHealth = hit.transform.gameObject.GetComponent<HealthController> ();
				castleHealth.Damage (attackDamage);
			}
		}
	}
}
