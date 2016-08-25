using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoText : MonoBehaviour {

	public int shotNumber;
	private Text txt;
	private ProjectileSwitcher pSwitcher;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text>();
		pSwitcher = GameObject.Find("UIManager").GetComponent<ProjectileSwitcher> ();
		shotNumber--;

		txt.text = ""+pSwitcher.projectileAmmo [shotNumber];
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = ""+pSwitcher.projectileAmmo [shotNumber];
	}
}
