using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text score;
	private int points = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		score.text = points.ToString();
		
	}

	public void addScore(int points) {
		this.points += points;
	}
}
