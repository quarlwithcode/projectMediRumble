using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	private Rigidbody2D projectile;			//	The rigidbody of the projectile
	public float resetSpeed = 0.025f;		//	The angular velocity threshold of the projectile, below which our game will reset
	
	private float resetSpeedSqr;			//	The square value of Reset Speed, for efficient calculation
	private SpringJoint2D spring;			//	The SpringJoint2D component which is destroyed when the projectile is launched
	private ProjectileDragging pDrag;
	private ProjectileSwitcher pSwitcher;
	public Vector3 startPosition;
	void Start ()
	{
		pSwitcher = GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ();
		projectile = pSwitcher.playerProjectile.GetComponent<Rigidbody2D>();
		if (projectile == null) {
			projectile = GameObject.FindGameObjectWithTag ("Projectile").GetComponent<Rigidbody2D> ();
		}

		//	Calculate the Resset Speed Squared from the Reset Speed
		resetSpeedSqr = resetSpeed * resetSpeed;

		//	Get the SpringJoint2D component through our reference to the GameObject's Rigidbody
		spring = projectile.GetComponent <SpringJoint2D>();

		pDrag = projectile.GetComponent<ProjectileDragging> ();

		//	Get the starting position of the game object
		startPosition = projectile.transform.position;
	}
	
	void Update () {
		projectile =  pSwitcher.playerProjectile.GetComponent<Rigidbody2D>();
		spring = projectile.GetComponent <SpringJoint2D>();
		pDrag = projectile.GetComponent<ProjectileDragging> ();

		//	If we hold down the "R" key...
		if (Input.GetKeyDown (KeyCode.R)) {
			//	... call the Reset() function
			Reset ();
		}

		//print (projectile.velocity.x);

		//	If the spring had been destroyed (indicating we have launched the projectile) and our projectile's velocity is below the threshold...
		if (!spring.enabled && Mathf.Abs(projectile.velocity.x) < .5f) {
			//	... call the Reset() function
			Reset ();
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		//	If the projectile leaves the Collider2D boundary...
		if (other.gameObject.tag == "Projectile") {
			//	... call the Reset() function
			Reset ();
		}
	}
	
	public void Reset () {
		//	The reset function will Reset the game by reloading the same level
		//Application.LoadLevel (Application.loadedLevel);
		projectile.isKinematic = true;
		if (pDrag.isShatterShot && pDrag.launched) {
			GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ().lowerScatterAmmo (1);
			//print ("yo");
			projectile.gameObject.GetComponent<ShatterProjectile> ().CancelCoroutines ();
		}

		if (pDrag.isExplodingShot && pDrag.launched) {
			GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ().lowerExplodingAmmo (1);
		} 
		pDrag.launched = false;
		//print (pDrag.isShatterShot);

		projectile.transform.position = startPosition;
		StartCoroutine (DelayLineRenderers ());
		spring.enabled = true;

	}

	public IEnumerator DelayLineRenderers(){
		yield return new WaitForSeconds(.05F);
		pDrag.catapultLineFront.enabled = true;
		pDrag.catapultLineBack.enabled = true;
	}

}
