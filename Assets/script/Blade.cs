using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	bool isCutting = false;
	Camera cam;

	GameObject currentBladeTrail;

	public GameObject bladeTrail;
	Rigidbody2D bladeRB;
	CircleCollider2D bladeCollider;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		bladeRB = GetComponent<Rigidbody2D> ();
		bladeCollider = GetComponent<CircleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			StartCutting ();
		} else if (Input.GetMouseButtonUp (0)) {
			StopCutting ();
		}

		if (isCutting) {
			UpdateCutGO ();
		}	
	}

	void StartCutting() {
		isCutting = true;
		currentBladeTrail = Instantiate (bladeTrail, transform);
		bladeCollider.enabled = true;
	}

	void StopCutting() {
		isCutting = false;
		currentBladeTrail.transform.SetParent (null);
		Destroy (currentBladeTrail, 2f);
		currentBladeTrail = null;
		bladeCollider.enabled = false;
	}

	void UpdateCutGO() {
		bladeRB.position = cam.ScreenToWorldPoint(Input.mousePosition);
	}
}
