using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour {

	public int direction;
	private Vector3 destroyPoint;

	public float minTime;
	public float maxTime;
	// Use this for initialization
	void Start () {
		destroyPoint = new Vector3 (transform.position.x + (30 * direction), transform.position.y, transform.position.z);
		LeanTween.moveX(gameObject, destroyPoint.x, Random.Range(minTime, maxTime)); 
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(destroyPoint, transform.position) < 1F) {
			Destroy (gameObject);
		}
	}
}
