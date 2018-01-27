	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidePod : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject juiceProducer;

	public float startForce = 15f;

	public Material[] materials;

	// Use this for initialization
	void Start () {

		gameObject.transform.Rotate (Vector3.right * 180);

		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.up * startForce * -1, ForceMode2D.Impulse);
		materials = new Material [2];
		materials [0] = transform.GetChild (0).GetChild (2).gameObject.GetComponent<Renderer>().material;
		materials [1] = transform.GetChild (0).GetChild (3).gameObject.GetComponent<Renderer>().material;

		Debug.Log (transform.GetChild (0).GetChild (2).gameObject);			

		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Blade") {
			GetComponent<CircleCollider2D> ().enabled = false;

			foreach (Transform child in transform) {
				Destroy (child.gameObject);
			}
				
			GameObject go = Instantiate (juiceProducer, transform);
			Debug.Log (go);
			go.GetComponent<Juice> ().materials = materials;
		}
	}


}
