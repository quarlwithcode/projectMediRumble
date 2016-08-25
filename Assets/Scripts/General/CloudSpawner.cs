using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	public GameObject[] clouds;
	public float yRange;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + Random.Range(-yRange, yRange), transform.position.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (clouds[Random.Range(0, clouds.Length)], spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}

