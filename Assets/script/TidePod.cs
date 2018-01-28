	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidePod : MonoBehaviour {

	Rigidbody2D rb;

	public GameObject juiceProducer;

	public float startForce = 15f;

	public Material[] materials;

	public int POINT_VALUE;

	private float spinRate;

	private PlayerController pcScript;

	// Use this for initialization
	void Start () {

		gameObject.transform.Rotate (Vector3.right * 180);

		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (transform.up * startForce * -1, ForceMode2D.Impulse);
		materials = new Material [2];
		materials [0] = transform.GetChild (0).GetChild (2).gameObject.GetComponent<Renderer>().material;
		materials [1] = transform.GetChild (0).GetChild (3).gameObject.GetComponent<Renderer>().material;		

		Destroy (gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, spinRate * Time.deltaTime);
	}

	public void setPCScript(PlayerController script) {
		pcScript = script;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Blade") {
			GetComponent<CircleCollider2D> ().enabled = false;
			pcScript.addScore (POINT_VALUE);

			foreach (Transform child in transform) {
				Destroy (child.gameObject);
			}
				
			GameObject go = Instantiate (juiceProducer, transform);
			go.GetComponent<Juice> ().materials = materials;
		} else if (col.tag == "KillBox") {
			GetComponent<CircleCollider2D> ().enabled = false;
			pcScript.loseLife ();
		}
	}

	public void setSpinRate(float rate) {
		spinRate = rate;
	}


}
