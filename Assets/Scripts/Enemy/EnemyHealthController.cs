using UnityEngine;
using System.Collections;

public class EnemyHealthController : HealthController {

	private EnemyMovement movementController;
	private EnemyAttack attackController;
	private Rigidbody2D rig2D;

	protected override void Start ()
	{
		base.Start ();
		movementController = GetComponent<EnemyMovement> ();
		attackController = GetComponent<EnemyAttack> ();

		rig2D = GetComponent<Rigidbody2D> ();
	}

	protected virtual void Update(){
		if (currentHealth <= 0 && alive) {
			Kill ();
			alive = false;
		}
	}

	public override void Kill ()
	{
		StartCoroutine (delayKill(2f));
	}

	public virtual IEnumerator delayKill(float time){
		movementController.enabled = false;
		attackController.enabled = false;
		rig2D.isKinematic = false;
		rig2D.AddForce (Vector2.up*5, ForceMode2D.Impulse);
		yield return new WaitForSeconds (time);
		Destroy (gameObject);
	}
}
