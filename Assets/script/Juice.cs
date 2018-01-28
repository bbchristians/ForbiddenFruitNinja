using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour {
	
	public int juiciness;
	public GameObject juice;

	public float maxRange = 1;

	private Vector2 vel;

	public Material[] materials;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < juiciness; i++) {
			Vector3 pos = new Vector3(Random.Range(-1*maxRange,maxRange),0f,0f) + transform.position;

			GameObject go = Instantiate (juice, pos, Quaternion.identity);
			go.transform.parent = transform;

			Material material = materials [Random.Range (0, 2)];
			go.GetComponent<Renderer> ().material = material;
			float rand = Random.value * 2;
			Vector3 curScale = go.transform.localScale;
			go.transform.localScale = new Vector3 (curScale.x * rand, curScale.y * rand, curScale.z * rand);

			Rigidbody rb = go.GetComponent<Rigidbody> ();
			rb.AddForce (vel * 100);
		}
		Destroy (gameObject, 5f);
	}

	public void addVelocityVector(Vector2 vel) {
		this.vel = vel;
	}
}
