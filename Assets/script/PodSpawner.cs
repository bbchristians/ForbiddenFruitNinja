using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodSpawner : MonoBehaviour {

	public GameObject pod;
	public GameObject FDA;

	public float chanceSpawnFDA = .1f;

	public Transform[] points;

	public float minDelay = 1f;
	public float maxDelay = 1f;

	public GameObject playerController;
	private PlayerController pcScript;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnPods ());
		pcScript = playerController.GetComponent<PlayerController> ();
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
			if (Random.value > chanceSpawnFDA) {
				GameObject go = Instantiate (pod, spawnPoint.position, spawnPoint.rotation);
				go.GetComponent<TidePod> ().setPCScript (pcScript);
			} else {
				GameObject go = Instantiate (FDA, spawnPoint.position, spawnPoint.rotation);
				go.GetComponent<FDA> ().setPCScript (pcScript);
			}
		}
	}
}
