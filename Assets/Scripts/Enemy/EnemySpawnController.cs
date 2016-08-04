using UnityEngine;
using System.Collections;

public class EnemySpawnController : MonoBehaviour {

	public GameObject enemy;
	public int enemyCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		//print ("spawn started");
		yield return new WaitForSeconds (startWait);
//		print ("spawn running1");
		while (true)
		{
//			print ("spawn running2");
			for (int i = 0; i < enemyCount; i++)
			{
				Instantiate (enemy, transform.position, Quaternion.identity);
//				print ("enemy spawned");
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
//		print ("spawn ran");
	}
}
