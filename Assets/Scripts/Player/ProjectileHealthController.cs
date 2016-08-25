using UnityEngine;
using System.Collections;

public class ProjectileHealthController : HealthController {

	protected bool destructStarted;
	protected PlayerProjectile projectile;

	protected override void Start ()
	{
		base.Start ();
		projectile = GetComponent<PlayerProjectile> ();
		destructStarted = false;
	}

	public override void Kill(){
		projectile.bounds.Reset ();
	}

	protected virtual void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ground") {
			Kill ();
		}
	}
}
