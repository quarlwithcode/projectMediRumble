using UnityEngine;
using System.Collections;

public class EnemyDoubleShoot : EnemyShoot {

	protected override void AutoAttack(){
		GameObject projectileClone;
		projectileClone = Instantiate (projectile, transform.GetChild (0).position, transform.GetChild (0).rotation) as GameObject;
		projectileClone.transform.GetChild(1).GetComponent<EnemyProjectile> ().SetDamage(attackDamage);
		projectileClone.transform.GetChild(1).GetComponent<Rigidbody2D> ().AddForce (new Vector2 (.7F, 1) * shotSpeed,ForceMode2D.Impulse);
		projectileClone = Instantiate (projectile, transform.GetChild (1).position, transform.GetChild (1).rotation) as GameObject;
		projectileClone.transform.GetChild(1).GetComponent<EnemyProjectile> ().SetDamage(attackDamage);
		projectileClone.transform.GetChild(1).GetComponent<Rigidbody2D> ().AddForce (new Vector2 (.7F, 1) * shotSpeed,ForceMode2D.Impulse);
	}

}
