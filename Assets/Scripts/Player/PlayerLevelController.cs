using UnityEngine;
using System.Collections;

public class PlayerLevelController : MonoBehaviour {

	public int currentLevel;
	public EnemySpawnController spawner;
	// Use this for initialization
	void Start () {
		currentLevel = 0;
		if (spawner == null)
			spawner = GameObject.Find ("EnemySpawnPoint").GetComponent<EnemySpawnController>();
	}
	
	// Update is called once per frame
	void Update () {
		currentLevel = spawner.wave;
	}
}
