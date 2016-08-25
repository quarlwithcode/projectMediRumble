using UnityEngine;
using System.Collections;

public class LeafSpawner : MonoBehaviour {

	public GameObject[] leaves;
	public int leafRange;
	public int leafCount;
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
			for (int i = 0; i < leafCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (transform.position.x+Random.Range(-leafRange/2, (leafRange/2)+1),
														transform.position.y,
															transform.position.z);
				//print (spawnPosition.x);
				Quaternion spawnRotation = Quaternion.identity;


				Instantiate (leaves[Random.Range(0, leaves.Length)], spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
