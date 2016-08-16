using UnityEngine;
using System.Collections;

public class EnemyRangedMovement : EnemyMovement {

	protected override void Start ()
	{
		attackStop = GameObject.Find("RangedStopPoint").GetComponent<Transform>();
		base.Start ();
	}
}
