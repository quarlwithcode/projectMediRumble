using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelText : MonoBehaviour {

	private PlayerLevelController playerLevel;
	private Text textController;

	// Use this for initialization
	void Start () {
		playerLevel = GameObject.FindGameObjectWithTag ("Castle").GetComponent<PlayerLevelController> ();
		textController = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		textController.text = "Level: " + playerLevel.currentLevel;
	}
}
