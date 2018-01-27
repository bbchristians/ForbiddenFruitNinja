	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidePod : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject juiceProducer;

	public float startForce = 15f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.up * startForce, ForceMode2D.Impulse);
		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Blade") {
			GameObject go = Instantiate (juiceProducer, transform);
			go.transform.SetParent (null);
			Destroy (gameObject);
		}
	}


}
