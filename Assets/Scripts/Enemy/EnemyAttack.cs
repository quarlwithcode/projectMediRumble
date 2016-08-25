using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {


	public int difficulty;
	public int attackDamage;
	public float attackRange;
	public float attackRate;
	public Transform target;
	public bool inRange;
	public LayerMask attackLayer;
	public bool attacking;

	// Use this for initialization
	protected virtual void Start () {
		target = GameObject.FindGameObjectWithTag ("Castle").GetComponent<Transform>();
		attacking = false;
		inRange = false;

		InvokeRepeating ("CheckRange", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		


	}

	protected virtual void OnDisable(){
		CancelInvoke ();
	}


	protected virtual void CheckRange(){
		//print ("checking for " + target.name);

		if (Vector2.Distance ((Vector2)transform.position, (Vector2)target.position) <= attackRange) {
			//print ("In Range");
			inRange = true;
			InvokeRepeating ("AutoAttack", 0f, attackRate);
			CancelInvoke ("CheckRange");
		}
	}

	protected virtual void AutoAttack(){
		//print ("attack");
		Vector2 rayOrigin = new Vector2 (transform.position.x + .51f, transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right, 50f, attackLayer);
		if (inRange) {
			//print (hit.transform.name);
			if (hit.transform.tag == "Castle") {
				//print ("Hit");
				HealthController castleHealth = hit.transform.gameObject.GetComponent<HealthController> ();
				castleHealth.Damage (attackDamage);
				attacking = true;
			}
		}
	}
}
