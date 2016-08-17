using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsController : MonoBehaviour {

	public int points;

	private Text textController;
	// Use this for initialization
	void Start () {
		points = 0;
		textController = GetComponent<Text> ();
		textController.text = "Points: " + points;
	}
	
	// Update is called once per frame
	void Update () {
		textController.text = "Points: " + points;
	}
}
