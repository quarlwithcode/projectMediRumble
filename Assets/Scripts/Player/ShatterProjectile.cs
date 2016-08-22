using UnityEngine;
using System.Collections;

public class ShatterProjectile : PlayerProjectile {

	public GameObject fragment;
	private int fragmentNumber = 3;
	public float fragmentSpeed;
	public float shatterTime;
	public float FragSpawnX;
	public float FragSpawnY;

	private bool coStarted;

	protected override void Start ()
	{
		base.Start ();
		coStarted = false;
	}

	// Use this for initialization
	protected override void Update () {
		base.Update ();
		if (pDragging.launched && pDragging.isShatterShot && !coStarted) {
			StartCoroutine (Shatter(shatterTime));
			coStarted = true;
		}
	}

	protected virtual IEnumerator Shatter(float time){
		yield return new WaitForSeconds (time);

		float fragVelX = -.5F;


		GameObject fragmentClone;
		for (int i = 0; i < fragmentNumber; i++) {
			Vector3 clonePos = new Vector3 (Random.Range (transform.position.x, transform.position.x + FragSpawnX), 
				Random.Range (transform.position.y, transform.position.y + FragSpawnY), transform.position.z);
			fragmentClone = Instantiate (fragment, clonePos, Quaternion.identity) as GameObject;
			fragmentClone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (fragVelX, -1) * fragmentSpeed, ForceMode2D.Impulse);
			fragVelX += .5F;
		}
		fragVelX = -.5F;
		CancelCoroutines ();
		bounds.Reset ();
	}

	public virtual void CancelCoroutines(){
		StopAllCoroutines ();
		coStarted = false;
	}
}
