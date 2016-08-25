using UnityEngine;
using System.Collections;

public class LeafController : MonoBehaviour {

	protected Transform leafDestroyer;
	public int minTime;
	public int maxTime;
	Vector3[,] curves;
	// Use this for initialization
	void Start () {
		curves = new Vector3[6,4];

		curves [0,0] = transform.position;
		curves [0,1] = new Vector3 (transform.position.x - 3, transform.position.y - 1.25F, transform.position.z);
		curves [0,2] = new Vector3 (transform.position.x + 3, transform.position.y - 2.5F, transform.position.z);
		curves [0,3] = new Vector3 (transform.position.x - 3, transform.position.y - 3.5F, transform.position.z);

		curves [1,0] = transform.position;
		curves [1,1] = new Vector3 (transform.position.x + 4.5f, transform.position.y - 1.25F, transform.position.z);
		curves [1,2] = new Vector3 (transform.position.x - 4.5f, transform.position.y - 2.5F, transform.position.z);
		curves [1,3] = new Vector3 (transform.position.x + 4.5f, transform.position.y - 3.5F, transform.position.z);

		curves [2,0] = transform.position;
		curves [2,1] = new Vector3 (transform.position.x - 6, transform.position.y - 1.25F, transform.position.z);
		curves [2,2] = new Vector3 (transform.position.x + 6, transform.position.y - 2.5F, transform.position.z);
		curves [2,3] = new Vector3 (transform.position.x - 6, transform.position.y - 3.5F, transform.position.z);

		curves [3,0] = transform.position;
		curves [3,1] = new Vector3 (transform.position.x + 3, transform.position.y - 1.25F, transform.position.z);
		curves [3,2] = new Vector3 (transform.position.x - 3, transform.position.y - 2.5F, transform.position.z);
		curves [3,3] = new Vector3 (transform.position.x + 3, transform.position.y - 3.5F, transform.position.z);

		curves [4,0] = transform.position;
		curves [4,1] = new Vector3 (transform.position.x - 4.5f, transform.position.y - 1.25F, transform.position.z);
		curves [4,2] = new Vector3 (transform.position.x + 4.5f, transform.position.y - 2.5F, transform.position.z);
		curves [4,3] = new Vector3 (transform.position.x - 4.5f, transform.position.y - 3.5F, transform.position.z);

		curves [5,0] = transform.position;
		curves [5,1] = new Vector3 (transform.position.x + 6, transform.position.y - 1.25F, transform.position.z);
		curves [5,2] = new Vector3 (transform.position.x - 6, transform.position.y - 2.5F, transform.position.z);
		curves [5,3] = new Vector3 (transform.position.x + 6, transform.position.y - 3.5F, transform.position.z);

		int rand = Random.Range (0,6);

		Vector3[] curve = new Vector3 [4];

		for (int i = 0; i < 4; i++) {
			curve [i] = curves [rand, i];
		}

		LTBezierPath path = new LTBezierPath (curve);

		leafDestroyer = GameObject.Find("LeafDestroyer").GetComponent<Transform>();
		LeanTween.moveY(gameObject, leafDestroyer.position.y, Random.Range(minTime, maxTime));
		LeanTween.move(gameObject, path, 12);

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < leafDestroyer.position.y) {
			Destroy (gameObject);
		}
	}
}
