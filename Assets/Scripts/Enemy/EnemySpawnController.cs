using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

	public GameObject[] enemies;
	public int enemyMetric;
	public int wave;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{	
		wave = 1;
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		//print ("spawn started");
		yield return new WaitForSeconds (startWait);
//		print ("spawn running1");
		while (true)
		{
			int difficultyCap = wave;

			if (difficultyCap >= enemies.Length) {
				difficultyCap = enemies.Length;
			}

			int difficultyPoints = wave * enemyMetric;

			//print (difficultyCap);
			//print (difficultyPoints);

//			print ("spawn running2");
			while(difficultyPoints > 0)
			{
				int randEnemy = Random.Range (0, difficultyCap);
				int enemyDifficulty;
				if(randEnemy == 2)
					enemyDifficulty = (enemies [randEnemy].GetComponent<EnemyAttack> ().difficulty*6);
				else 
					enemyDifficulty = enemies [randEnemy].GetComponent<EnemyAttack> ().difficulty;
				if (difficultyPoints - enemyDifficulty >= 0) {
					difficultyPoints -= enemyDifficulty;
					Instantiate (enemies [randEnemy], new Vector3(transform.position.x, 
						enemies[randEnemy].transform.position.y, 
						transform.position.z), Quaternion.identity);
				} else if(difficultyPoints > 0) {
					difficultyPoints -= enemies [0].GetComponent<EnemyAttack> ().difficulty;
					Instantiate (enemies [0], transform.position, Quaternion.identity);
				}

//				print ("enemy spawned");
				yield return new WaitForSeconds (spawnWait);
			}


			yield return new WaitForSeconds (waveWait);
			wave++;
			yield return new WaitForSeconds (startWait);
		}
//		print ("spawn ran");
	}
}
