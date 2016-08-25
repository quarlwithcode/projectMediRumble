using UnityEngine;
using System.Collections;

public class PlayerProjectileUpgrade : MonoBehaviour {

	private PlayerLevelController playerLevel;
	private ProjectileDragging pDrag;
	public int[] upgradeLevels;
	private bool[] upgradeShot;
	private bool[] hasUpgraded;
	private bool[] hasShownUnlock;
	public UIManager uiManager;
	// Use this for initialization
	void Start () {
		if(uiManager == null)
			uiManager = GameObject.Find ("UIManager").GetComponent<UIManager> ();



		playerLevel = GetComponent<PlayerLevelController> ();

		upgradeShot = new bool[upgradeLevels.Length];
		hasUpgraded = new bool[upgradeLevels.Length];
		hasShownUnlock = new bool[upgradeLevels.Length];

		for (int i = 0; i < upgradeShot.Length; i++) {
			upgradeShot [i] = false;
			hasUpgraded[i] = false;
			hasShownUnlock[i] = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if (CheckUpgrade ()) {
			pDrag = GameObject.Find ("UIManager").GetComponent<ProjectileSwitcher> ().playerProjectile.GetComponent<ProjectileDragging> ();
			Upgrade ();
		}

	}

	bool CheckUpgrade(){
		for (int i = 0; i < upgradeLevels.Length; i++) {
			if (playerLevel.currentLevel == upgradeLevels [i] && !hasShownUnlock[i]) {
				upgradeShot [i] = true;
				return upgradeShot [i];
			}
		}

		return false;
	}

	void Upgrade(){
		if (playerLevel.currentLevel == upgradeLevels [0] && !hasUpgraded[0]) {
			uiManager.unlockProjectileButton (1);
			hasUpgraded[0] = true;
		} else if(playerLevel.currentLevel == upgradeLevels [1] && !hasUpgraded[1]) {
			uiManager.unlockProjectileButton (2);
			hasUpgraded[1] = true;
		}

		if (hasUpgraded[0] && !hasShownUnlock[0] && !pDrag.clickedOn) {
			if (!pDrag.launched || (pDrag.launched && pDrag.transform.position.x < 7)) {
				uiManager.showUnlock1 ();
				hasShownUnlock [0] = true;
			}
		} else if (hasUpgraded[1] && !hasShownUnlock[1] && !pDrag.clickedOn) {
			if (!pDrag.launched || (pDrag.launched && pDrag.transform.position.x < 7)) {
				uiManager.showUnlock2 ();
				hasShownUnlock [1] = true;
			}
		}
	}
}
