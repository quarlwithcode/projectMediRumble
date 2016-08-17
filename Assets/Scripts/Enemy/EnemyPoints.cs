using UnityEngine;
using System.Collections;

public class EnemyPoints : MonoBehaviour {

	private PointsController playerPoints;
	public int points;
	// Use this for initialization
	void Start () {
		playerPoints = GameObject.Find ("PointsTxt").GetComponent<PointsController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addPoints(){
		//print ("add points ran");
		playerPoints.points += points;
	}
}
