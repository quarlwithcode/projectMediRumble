using UnityEngine;
using System.Collections;

public class EnemyAnimController : MonoBehaviour {

	EnemyAttack attackController;
	Animator anim;
	// Use this for initialization
	void Start () {
		attackController = GetComponent<EnemyAttack> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attackController.inRange) {
			anim.SetBool ("inRange", true);
		}

		if (attackController.attacking) {
			anim.SetBool ("attack", true);
			attackController.attacking = false;
		} else {
			anim.SetBool ("attack", false);
		}
	}
}
