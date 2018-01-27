	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidePod : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject juiceProducer;

	public float startForce = 15f;

	// Use this for initialization
	void Start () {

		gameObject.transform.Rotate (Vector3.right * 180);

		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.up * startForce * -1, ForceMode2D.Impulse);
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Blade") {
			GameObject go = Instantiate (juiceProducer, transform);
			Debug.Log (go);
			Destroy (gameObject);
		}
	}


}
