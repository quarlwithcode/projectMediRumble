using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	protected Transform attackStop;
	public float movementTimeMin;
	public float movementTimeMax;
	public int xRange;
	protected float movementTime;
	protected EnemyAttack attackController;
	// Use this for initialization
	protected virtual void Start () {
		if(attackStop == null)
			attackStop = GameObject.Find("MeleeStopPoint").GetComponent<Transform>();
		LeanTween.init (800);
		attackController = GetComponent<EnemyAttack> ();

		movementTime = Random.Range (movementTimeMin, movementTimeMax);
		LeanTween.moveX (gameObject, attackStop.position.x+Random.Range(0,xRange), movementTime);
	}
	
	// Update is called once per frame
	protected virtual void FixedUpdate () {
		if (attackController.inRange) {
			LeanTween.cancel (gameObject);
		}
	}

	protected virtual void OnDisable(){
		LeanTween.cancel (gameObject);
	}

	public Vector3 getStopPoint(){
		return attackStop.position;
	}
}
