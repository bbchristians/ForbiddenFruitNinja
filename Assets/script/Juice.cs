using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour {
	
	public int juiciness;
	public GameObject juice;

	public float maxRange = 1;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < juiciness; i++) {
			Vector3 pos = new Vector3(Random.Range(-1*maxRange,maxRange),0,0);
			Instantiate (juice, pos, Quaternion.identity);
		}
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
