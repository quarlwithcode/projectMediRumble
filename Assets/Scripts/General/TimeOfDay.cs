using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour {

	private int dayLength;   //in minutes
	private int dayStart;
	private int nightStart;   //also in minutes
	private int currentTime;
	public float cycleSpeed;
	private bool isDay;
	private Vector3 sunPosition;
	public Light sun;
	public GameObject earth;
	public SpriteRenderer sky;

	// Day and Night Script for 2d,
	// Unity needs one empty GameObject (earth) and one Light (sun)
	// make the sun a child of the earth
	// reset the earth position to 0,0,0 and move the sun to -200,0,0
	// attach script to sun
	// add sun and earth to script publics
	// set sun to directional light and y angle to 90


	void Start() {
		dayLength = 1440;
		dayStart = 300;
		nightStart = 1200;
		currentTime = 720;
		StartCoroutine( CalcTime ());

	}

	void Update() {

		if (currentTime > 0 && currentTime < dayStart) {
			isDay =false;
			sun.intensity = 0;
		} else if (currentTime >= dayStart && currentTime < nightStart) {
			isDay = true;
			sun.intensity = 1;
		} else if (currentTime >= nightStart && currentTime < dayLength) {
			isDay = false;
			sun.intensity = 0;
		} else if (currentTime >= dayLength) {
			currentTime = 0;
		}
		float currentTimeF = currentTime;
		float dayLengthF = dayLength;
	}

	IEnumerator CalcTime(){
		while (true) {
			currentTime += 1;
			int hours = Mathf.RoundToInt( currentTime / 60);
			int minutes = currentTime % 60;
			//Debug.Log (hours+":"+minutes);
			//print (Time.timeSinceLevelLoad);
			if (currentTime % 60 == 0){
				if (isDay) {
					sky.color = new Color (sky.color.r, sky.color.g - .08F, sky.color.b - .08F);
				} else {
					sky.color = new Color (sky.color.r, sky.color.g + .08F, sky.color.b + .08F);
				}
			}

			yield return new WaitForSeconds(1F/cycleSpeed);
		}
	}
}
