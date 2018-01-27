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
			Vector3 pos = new Vector3(Random.Range(-1*maxRange,maxRange),0f,0f);

			float rotate = Input.GetAxis ("Vertical") * -90f;

			GameObject go = Instantiate (juice, pos, Quaternion.identity);
			go.transform.Rotate (Vector3.right * 90);
			Debug.Log (go.transform);
			Debug.Log (go.transform.rotation);

			Debug.Log (go.transform.position);
		}
		Destroy (gameObject, 5f);
	}
}
