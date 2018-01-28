using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDA : MonoBehaviour {

	public float startForce = 14f;
	Rigidbody2D rb;

	PlayerController pcScript;

	// Use this for initialization
	void Start () {rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.up * startForce, ForceMode2D.Impulse);	

		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setPCScript(PlayerController script) {
		pcScript = script;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Blade") {
			GetComponent<CircleCollider2D> ().enabled = false;

			foreach (Transform child in transform) {
				Destroy (child.gameObject);
			}

			pcScript.loseLife ();

			//GameObject go = Instantiate (juiceProducer, transform);
		}
	}
}
