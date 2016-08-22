using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour {
	private bool lvlStarted;
	private GameObject startMenu;
	public GameObject gameOverMenu;
	public GameObject[] unlockScreens;
	public GameObject[] projectileButtons;
	// Use this for initialization
	void Start () {
		lvlStarted = false;
		Time.timeScale = 0;
		startMenu = GameObject.FindGameObjectWithTag ("StartMenu");

		if (gameOverMenu == null) {
			gameOverMenu = GameObject.FindGameObjectWithTag ("GameOverMenu");
		}

		hideAllUnlock ();
		hideProjectileButtons ();
		showStartMenu ();
		hideGameOverMenu ();
		print ("ran");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hideGameOverMenu(){
		gameOverMenu.SetActive (false);
	}

	public void showGameOverMenu(){
		gameOverMenu.SetActive (true);
	}

	private void hideStartMenu(){
		startMenu.SetActive (false);
	}

	private void showStartMenu(){
		startMenu.SetActive (true);
	}

	public void hideAllUnlock(){
		foreach (GameObject screen in unlockScreens) {
			screen.SetActive (false);
		}
	}

	public void showUnlock1(){
		if (unlockScreens.Length > 0) {
			Time.timeScale = 0;
			unlockScreens [0].SetActive (true);
		}
	}

	public void hideUnlock1(){
		if (unlockScreens.Length > 0) {
			unlockScreens [0].SetActive (false);
		}
	}

	public void quitUnlock1(){
		Time.timeScale = 1;
		unlockProjectileButton (1);
		hideUnlock1 ();
	}

	public void showUnlock2(){
		if (unlockScreens.Length > 0) {
			Time.timeScale = 0;
			unlockScreens [1].SetActive (true);
		}
	}

	public void hideUnlock2(){
		if (unlockScreens.Length > 0) {
			unlockScreens [1].SetActive (false);
		}
	}

	public void quitUnlock2(){
		Time.timeScale = 1;
		unlockProjectileButton (2);
		hideUnlock2 ();
	}

	public void hideProjectileButtons(){
		for(int i = 1; i < projectileButtons.Length; i++) {
			projectileButtons[i].SetActive (false);		
		}
	}

	public void unlockProjectileButton(int button){
		for (int i = 0; i < button; i++) {
			projectileButtons [i].GetComponent<RectTransform> ().position = new Vector3 (
				projectileButtons [i].GetComponent<RectTransform> ().position.x-120, 
				projectileButtons [i].GetComponent<RectTransform> ().position.y, 
				projectileButtons [i].GetComponent<RectTransform> ().position.z);
		}
		projectileButtons [button].SetActive (true);
	}

	public void PauseControl(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
		} else if (Time.timeScale == 1) {
			Time.timeScale = 0;
		}
	}
		
	public void StartGame(){
		Time.timeScale = 1;
		hideStartMenu ();
	}

	public void ResetGame(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void QuitGame(){
		Application.Quit ();
	}


}
