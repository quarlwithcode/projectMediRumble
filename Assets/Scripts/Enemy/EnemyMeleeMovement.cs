using UnityEngine;
using System.Collections;

public class EnemyMeleeMovement : EnemyMovement {

	protected override void Start ()
	{
		attackStop = GameObject.Find("MeleeStopPoint").GetComponent<Transform>();
		base.Start ();
	}
}
