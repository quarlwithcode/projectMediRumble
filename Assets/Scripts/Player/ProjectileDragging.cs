using UnityEngine;

public class ProjectileDragging : MonoBehaviour {
	public float maxStretch = 3.0f;
	public float velocityMultiplier;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;  
	
	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	public bool clickedOn;
	private Vector2 prevVelocity;
	public bool launched;
	public bool isShatterShot;
	public bool isExplodingShot;

	private Vector3 startPos;
	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		catapult = spring.connectedBody.transform;

		startPos = transform.position;
	}
	
	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = GetComponent<Collider2D>() as CircleCollider2D;
		circleRadius = circle.radius;
		launched = false;
	}
	
	void Update () {
		if (clickedOn)
			Dragging ();
		
		if (spring != null) {
			if (!GetComponent<Rigidbody2D>().isKinematic && prevVelocity.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude) {
				spring.enabled = false;
				catapultLineFront.enabled = false;
				catapultLineBack.enabled = false;

				if (!launched) {
					//print (prevVelocity);
					GetComponent<Rigidbody2D> ().AddForce (prevVelocity*velocityMultiplier, ForceMode2D.Impulse);
					launched = true;
				}
				//print (GetComponent<Rigidbody2D> ().velocity);
			}
			
			if (!clickedOn)
				prevVelocity = GetComponent<Rigidbody2D>().velocity;
			
			LineRendererUpdate ();


		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}

		if (Vector3.Distance(transform.position, startPos) < 0.0001f && !clickedOn) {
			launched = false;
		}

		if (isShatterShot && GetComponent<Rigidbody2D>().velocity == Vector2.zero && !clickedOn) {
			GetComponent<ShatterProjectile> ().CancelCoroutines ();
			launched = false;
		}
	}
	
	void LineRendererSetup () {
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

		
		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineFront.sortingLayerID = SortingLayer.NameToID("Foreground");
		catapultLineBack.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerID = SortingLayer.NameToID("Foreground");
		
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}
	
	void OnMouseDown () {
		spring.enabled = false;
		clickedOn = true;
	}
	
	void OnMouseUp () {
		spring.enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		clickedOn = false;
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		
		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition(1, holdPoint);
		catapultLineBack.SetPosition(1, holdPoint);
	}
}
