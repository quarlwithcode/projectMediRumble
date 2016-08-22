using UnityEngine;
using System.Collections;

public class EnemyAirBalloonMovement : EnemyMovement {

	protected override void Start ()
	{
		attackStop = GameObject.Find("AirBalloonStopPoint").GetComponent<Transform>();
		base.Start ();
	}
}