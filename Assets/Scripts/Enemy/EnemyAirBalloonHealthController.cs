using UnityEngine;
using System.Collections;

public class EnemyAirBalloonHealthController : EnemyHealthController {

	public GameObject drop;
	private bool dropped = false;
	[Range(0,100)] public float dropChance;

	protected override void onKill ()
	{
		if (currentHealth <= 0 && !dropped) {
			float check = Random.Range (0, 100);
			print (dropChance);
			print (check);
			if (check < dropChance) {
				print (true);
				GameObject dropClone;
				dropClone = Instantiate (drop, transform.position, transform.rotation) as GameObject;
				print (dropClone.name);
				dropped = true;
			}
		}
	}
}
