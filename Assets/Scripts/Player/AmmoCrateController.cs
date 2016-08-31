using UnityEngine;
using System.Collections;

public class AmmoCrateController : MonoBehaviour {


	protected ProjectileSwitcher pSwitcher;
	protected Collider2D[] col2D;

	// Use this for initialization
	void Start () {
		pSwitcher = GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ();
		col2D = GetComponents<Collider2D> ();
		DisableCollider ();
		Invoke ("EnableCollider", .8F);
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

	void EnableCollider(){
		foreach (Collider2D col in col2D) {
			col.enabled = true;
		}
	}

	void DisableCollider(){
		foreach (Collider2D col in col2D) {
			col.enabled = false;
		}
	}
}
