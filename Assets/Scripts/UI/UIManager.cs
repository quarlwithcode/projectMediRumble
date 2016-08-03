using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	private bool lvlStarted;
	private GameObject startMenu;
	// Use this for initialization
	void Start () {
		lvlStarted = false;
		Time.timeScale = 0;
		startMenu = GameObject.FindGameObjectWithTag ("StartMenu");
		showStartMenu ();

		print ("ran");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void hideStartMenu(){
		startMenu.SetActive (false);
	}

	private void showStartMenu(){
		startMenu.SetActive (true);
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

	public void QuitGame(){
		Application.Quit ();
	}


}
