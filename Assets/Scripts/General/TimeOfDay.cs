using UnityEngine;
using System.Collections;

public class TimeOfDay : MonoBehaviour {

	private int dayLength;   //in minutes
	private int dayStart;
	private int nightStart;   //also in minutes
	private int currentTime;
	public float cycleSpeed;
	private bool isDay;
	private bool nightActive;
	private Vector3 sunPosition;
	public Light sun;
	public GameObject earth;
	public SpriteRenderer sky;
	[Range(6F,100F)]public float skyRate;
	private GameObject[] clouds;

	// Day and Night Script for 2d,
	// Unity needs one empty GameObject (earth) and one Light (sun)
	// make the sun a child of the earth
	// reset the earth position to 0,0,0 and move the sun to -200,0,0
	// attach script to sun
	// add sun and earth to script publics
	// set sun to directional light and y angle to 90


	void Start() {
		clouds = GameObject.FindGameObjectsWithTag ("Cloud");
		dayLength = 1440;
		dayStart = 300;
		nightStart = 1140;
		currentTime = 720;
		StartCoroutine( CalcTime ());

	}

	void Update() {
		clouds = GameObject.FindGameObjectsWithTag ("Cloud");
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
		float i = 1F;
		float c = 1F;
		while (true) {
			currentTime += 1;
			int hours = Mathf.RoundToInt( currentTime / 60);
			int minutes = currentTime % 60;
			//Debug.Log (hours+":"+minutes);
			//print (Time.timeSinceLevelLoad);
			if (!isDay) {
				sky.color = new Color (1, 1, 1, i);
				i -= .00069F*skyRate;

				foreach (GameObject cloud in clouds) {
					cloud.GetComponent<SpriteRenderer> ().color = new Color (c, c, c, cloud.GetComponent<SpriteRenderer> ().color.a);
				}
				c -= .000345F * skyRate;
			} else {
				sky.color = new Color (1, 1, 1, i);
				i += .00069F*skyRate;
				foreach (GameObject cloud in clouds) {
					cloud.GetComponent<SpriteRenderer> ().color = new Color (c, c, c, cloud.GetComponent<SpriteRenderer> ().color.a);
				}
				c += .000345F * skyRate;
			}

			if (i < 0f) {
				i = 0F;
			}

			if (i > 1f) {
				i = 1F;
			}

			if (c < .5f) {
				c = .5F;
			}

			if (c > 1f) {
				c = 1F;
			}

			yield return new WaitForSeconds(1F/cycleSpeed);
		}
	}

	IEnumerator turnNight(){
		float i = .99F;
		print ("ran");
		while (sky.color.a > 0) {
			sky.color = new Color (1, 1, 1, i);
			i -= .001F;
			yield return new WaitForSeconds (1F / cycleSpeed);
		}
	}

	IEnumerator turnDay(){
		float i = 0F;
		while (sky.color.a < 1) {
			sky.color = new Color (1, 1, 1, i);
			i += .001F;
			yield return new WaitForSeconds (1F / cycleSpeed);
		}
	}
}
