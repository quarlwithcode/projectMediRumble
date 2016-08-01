﻿using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public int maxHealth;


	protected int currentHealth;

	// Use this for initialization
	protected virtual void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Restore(int restoration){
		currentHealth += restoration;
	}

	public virtual void Damage(int damage){
		currentHealth -= damage;
	}

	public virtual int getHealth (){
		return currentHealth;
	}

}
