using UnityEngine;
using System.Collections;

public class PlayerProjectileUpgrade : MonoBehaviour {

	private PlayerLevelController playerLevel;
	public int[] upgradeLevels;
	private bool[] upgradeShot;
	private bool[] hasUpgraded;
	public UIManager uiManager;
	// Use this for initialization
	void Start () {
		if(uiManager == null)
			uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> ();

		playerLevel = GetComponent<PlayerLevelController> ();

		upgradeShot = new bool[upgradeLevels.Length];
		hasUpgraded = new bool[upgradeLevels.Length];

		for (int i = 0; i < upgradeShot.Length; i++) {
			upgradeShot [i] = false;
			hasUpgraded[i] = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if (CheckUpgrade ()) {
			Upgrade ();
		}

	}

	bool CheckUpgrade(){
		for (int i = 0; i < upgradeLevels.Length; i++) {
			if (playerLevel.currentLevel == upgradeLevels [i] && !hasUpgraded[i]) {
				upgradeShot [i] = true;
				return upgradeShot [i];
			}
		}

		return false;
	}

	void Upgrade(){
		if (playerLevel.currentLevel == upgradeLevels [0] && !hasUpgraded[0]) {
			uiManager.showUnlock1 ();
			hasUpgraded[0] = true;
		} else if(playerLevel.currentLevel == upgradeLevels [1] && !hasUpgraded[1]) {
			uiManager.showUnlock2 ();
			hasUpgraded[1] = true;
		}
	}
}
