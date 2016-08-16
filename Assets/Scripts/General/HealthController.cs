﻿using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int maxHealth;
	public bool alive;


	protected int currentHealth;

	// Use this for initialization
	protected virtual void Start () {
		currentHealth = maxHealth;
		alive = true;
	}

	protected virtual void Update () {
		if (currentHealth <= 0) {
			currentHealth = 0;
		}

		if (currentHealth <= 0 && alive) {
			Kill ();
			alive = false;
		}
	}

	public virtual void Restore(int restoration){
		currentHealth += restoration;
	}

	public virtual void Damage(){
		currentHealth --;
	}

	public virtual void Damage(int damage){
		currentHealth -= damage;
	}

	public virtual int getHealth (){
		return currentHealth;
	}

	public virtual void Kill(){
		Destroy (gameObject);
	}

}
