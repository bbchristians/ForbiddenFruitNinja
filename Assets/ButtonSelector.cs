using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour {

	public List<Color> colors;
	public GameObject go1;
	public GameObject go2;
	public GameObject go3;
	public GameObject go4;

	// Use this for initialization
	void Start () {
		go1.GetComponent<Image> ().material.color = colors [0];
		go2.GetComponent<Image> ().material.color = colors [1];
		go3.GetComponent<Image> ().material.color = colors [0];
		go4.GetComponent<Image> ().material.color = colors [1];
	}


}
