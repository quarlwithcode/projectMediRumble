using UnityEngine;
using System.Collections;

public class EnemyHealthController : HealthController {

	protected EnemyMovement movementController;
	protected EnemyAttack attackController;
	protected EnemyPoints pointsController;
	protected Rigidbody2D rig2D;

	protected override void Start ()
	{
		base.Start ();
		movementController = GetComponent<EnemyMovement> ();
		attackController = GetComponent<EnemyAttack> ();
		pointsController = GetComponent<EnemyPoints> ();
		rig2D = GetComponent<Rigidbody2D> ();
	}

	protected override void Update(){
		if (currentHealth <= 0 && alive) {
			Kill ();
			alive = false;
		}

		if (!alive) {
			transform.Rotate (Vector3.forward*100F* Time.deltaTime);
		}
	}

	protected virtual void onKill ()
	{
		return;
	}

	public override void Kill ()
	{
		onKill ();
		StartCoroutine (delayKill(2f));
	}

	public virtual IEnumerator delayKill(float time){
		movementController.enabled = false;
		attackController.enabled = false;
		pointsController.addPoints ();
		rig2D.isKinematic = false;
		rig2D.AddForce (Vector2.up*3.5F, ForceMode2D.Impulse);
		if (GetComponent<Animator> () != null) {
			GetComponent<Animator> ().enabled = false;
		}
		yield return new WaitForSeconds (time);
		Destroy (gameObject);
	}
}
