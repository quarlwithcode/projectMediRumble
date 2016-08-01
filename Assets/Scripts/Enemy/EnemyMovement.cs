using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Transform attackStop;
	public float movementTimeMin;
	public float movementTimeMax;

	private float movementTime;
	private EnemyAttack attackController;
	// Use this for initialization
	void Start () {
		LeanTween.init (800);
		attackController = GetComponent<EnemyAttack> ();

		movementTime = Random.Range (movementTimeMin, movementTimeMax);
		LeanTween.moveX (gameObject, attackStop.position.x, movementTime);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (attackController.inRange) {
			LeanTween.cancel (gameObject);
		}

	}
}
