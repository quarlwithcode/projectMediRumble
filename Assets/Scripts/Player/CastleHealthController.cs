using UnityEngine;
using System.Collections;

public class CastleHealthController : HealthController {

	public override void Kill(){
		GameObject.Find("UIManager").GetComponent<UIManager> ().showGameOverMenu ();
	}
}
