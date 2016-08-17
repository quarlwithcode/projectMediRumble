using UnityEngine;
using System.Collections;

public class PlayerProjectileUpgrade : MonoBehaviour {

	private PlayerLevelController playerLevel;
	public bool activateUpgrade;
	public int numUpgrades = 1;
	// Use this for initialization
	void Start () {
		playerLevel = GetComponent<PlayerLevelController> ();

	}

	// Update is called once per frame
	void Update () {
		if (playerLevel.currentLevel == 3) {
			
		}
	}

	public void Upgrade(int level){
		if (level == 3) {
			
		}
	}
}
