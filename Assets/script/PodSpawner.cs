using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodSpawner : MonoBehaviour {

	public GameObject pod;
	public Transform[] points;



	public float minDelay = 1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnPods ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnPods() {
		while (true) {

			float delay = Random.Range (minDelay, maxDelay);
			yield return new WaitForSeconds (delay);

			int spawnIndex = Random.Range (0, points.Length);
			Transform spawnPoint = points [spawnIndex];

			GameObject go = Instantiate (pod, spawnPoint.position, spawnPoint.rotation);
		}
	}
}
