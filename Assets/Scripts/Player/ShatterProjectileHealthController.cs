using UnityEngine;
using System.Collections;

public class ShatterProjectileHealthController : ProjectileHealthController {

	public override void Kill(){
		GetComponent<ShatterProjectile> ().CancelCoroutines ();
		projectile.bounds.Reset ();
	}
}
