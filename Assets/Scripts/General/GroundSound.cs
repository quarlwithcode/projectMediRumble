using UnityEngine;
using System.Collections;

public class GroundSound : MonoBehaviour {

	public AudioClip explosion;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "ExplodingProjectile") {
			source.PlayOneShot (explosion, .8F);
		}
	}

}
