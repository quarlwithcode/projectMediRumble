using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSlider : MonoBehaviour {

	public HealthController castleHealth;

	private Slider sldr;
	private Image fillImg;

	// Use this for initialization
	void Start () {
		sldr = GetComponent<Slider> ();
		sldr.maxValue = castleHealth.maxHealth;
		sldr.minValue = 0;
		sldr.value = castleHealth.getHealth ();

		fillImg = sldr.fillRect.GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		sldr.value = castleHealth.getHealth ();

		Color fillClr = new Color (((float)castleHealth.maxHealth/100F)-((float)castleHealth.getHealth ()/100F),
			((float)castleHealth.getHealth () / castleHealth.maxHealth),
			 0F, 1F);

		 

		fillImg.color = fillClr;
	}
}
