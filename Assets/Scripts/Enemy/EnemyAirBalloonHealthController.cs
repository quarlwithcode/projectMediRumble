using UnityEngine;
using System.Collections;

public class EnemyAirBalloonHealthController : EnemyHealthController {

	public GameObject drop;
	[Range(0F,1F)] public float dropChance;

	public override IEnumerator delayKill (float time)
	{
		float check = Random.Range (0F, 1F);
		if (check < dropChance) {
			Instantiate (drop, transform.position, transform.rotation);
		}
		return base.delayKill (time);
	}
}
