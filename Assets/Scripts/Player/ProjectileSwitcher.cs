using UnityEngine;
using System.Collections;

public class ProjectileSwitcher : MonoBehaviour {

	public GameObject[] projectiles;
	public int[] projectileAmmo;
	public PlayerProjectile playerProjectile;
	// Use this for initialization
	void Start () {
		turnOnNormalProjectile ();
		if (projectiles.Length == 0) {
			projectiles = new GameObject[1];
			projectiles [0] = GameObject.FindGameObjectWithTag ("Projectile");
		}
	}
	
	// Update is called once per frame
	void Update () {
		int ammoIndex = 0;
		foreach (int ammoCounter in projectileAmmo) {
			if (ammoCounter <= 0 && ammoIndex > 0) {
				projectileAmmo[ammoIndex] = 0;
			}
			ammoIndex++;
		}

		if (Input.GetKeyDown (KeyCode.Q) && projectileAmmo[0] != 0) {
			turnOnNormalProjectile ();
		} else if (Input.GetKeyDown (KeyCode.W) && projectileAmmo[1] != 0) {
			turnOnScatterProjectile ();
		} else if (Input.GetKeyDown (KeyCode.E) && projectileAmmo[2] != 0) {
			turnOnExplodingProjectile ();
		}

		if (playerProjectile.name == "ScatterProjectile" && projectileAmmo [1] <= 0) {
			turnOnNormalProjectile ();
		} else if (playerProjectile.name == "ExplodingProjectile" && projectileAmmo [2] <= 0) {
			turnOnNormalProjectile ();
		}


	}

	public void turnOnNormalProjectile(){
		foreach (GameObject projectile in projectiles) {
			PlayerProjectile checkProjectile = projectile.GetComponent<PlayerProjectile> ();
			if (checkProjectile != null) {
				if (checkProjectile.name == "Projectile") {
					checkProjectile.gameObject.SetActive (true);
					playerProjectile = projectile.GetComponent<PlayerProjectile> ();
				} else {
					checkProjectile.gameObject.SetActive (false);
				}
			}
		}
	}

	public void turnOnScatterProjectile(){
		foreach (GameObject projectile in projectiles) {
			PlayerProjectile checkProjectile = projectile.GetComponent<PlayerProjectile> ();
			if (checkProjectile != null) {
				if (checkProjectile.name == "ScatterProjectile") {
					checkProjectile.gameObject.SetActive (true);
					playerProjectile = projectile.GetComponent<PlayerProjectile> ();
				} else {
					checkProjectile.gameObject.SetActive (false);
				}
			}
		}
	}

	public void turnOnExplodingProjectile(){
		foreach (GameObject projectile in projectiles) {
			PlayerProjectile checkProjectile = projectile.GetComponent<PlayerProjectile> ();
			if (checkProjectile != null) {
				if (checkProjectile.name == "ExplodingProjectile") {
					checkProjectile.gameObject.SetActive (true);
					playerProjectile = projectile.GetComponent<PlayerProjectile> ();
				} else {
					checkProjectile.gameObject.SetActive (false);
				}
			}
		}
	}

	public void lowerScatterAmmo(int shotAmmo){
		projectileAmmo [1] -= shotAmmo;
	}

	public void lowerExplodingAmmo(int shotAmmo){
		projectileAmmo [2] -= shotAmmo;
	}
}
