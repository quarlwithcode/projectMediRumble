using UnityEngine;
using System.Collections;

public class ExplodingProjectile : PlayerProjectile{

	public GameObject explosion;


	protected override void Start ()
	{
		base.Start ();

	}

	protected virtual void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			GameObject explosionClone;
			explosionClone = Instantiate(explosion, new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, transform.position.z), Quaternion.identity) as GameObject;
			health.Kill ();
		}
	}
}
