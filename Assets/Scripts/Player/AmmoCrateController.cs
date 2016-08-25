using UnityEngine;
using System.Collections;

public class AmmoCrateController : MonoBehaviour {

	protected ProjectileSwitcher pSwitcher;

	// Use this for initialization
	void Start () {
		pSwitcher = GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Projectile") {
			pSwitcher.ResetAmmo ();
			Destroy (gameObject);
		}
	}
}
