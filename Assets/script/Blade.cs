using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	bool isCutting = false;
	Camera cam;

	GameObject currentBladeTrail;

	public GameObject bladeTrail;
	public float velocity;

	public float minSlashSpeed;

	public Vector2 movementVector;

	private Vector2 lastPos;
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
		Vector2 curLoc = Input.mousePosition;
		movementVector = curLoc - lastPos;
		velocity = (movementVector).magnitude / Time.deltaTime;
		lastPos = curLoc;

		if (bladeRB == null) {
			return;
		}
		if (Input.GetMouseButtonDown (0)) {
			StartCutting ();
		} else if (Input.GetMouseButtonUp (0)) {
			StopCutting ();
		}

		if (isCutting) {
			UpdateCutGO ();
			if (velocity < minSlashSpeed) {
				bladeCollider.enabled = false;
			} else {
				bladeCollider.enabled = true;
			}
		}	
	}

	void StartCutting() {
		isCutting = true;
		currentBladeTrail = Instantiate (bladeTrail, transform);
		currentBladeTrail.GetComponent<TrailRenderer> ().enabled = false;
		//bladeCollider.enabled = true;
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
		currentBladeTrail.GetComponent<TrailRenderer> ().enabled = true;
	}
}
