using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

	public HealthController castleHealth;

	private Text textController;

	// Use this for initialization
	void Start () {
		textController = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		textController.text = "Health: " + castleHealth.getHealth () + "/" + castleHealth.maxHealth; 
	}
}
