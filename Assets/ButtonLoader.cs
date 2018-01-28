using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoader : MonoBehaviour {

	public List<List<Color>> colors;

	public GameObject button;

	public float lasty = 0;
	public float inc = 50;
	private float x;

	// Use this for initialization
	void Start () {
		colors = new List<List<Color>> ();
		lasty = transform.position.y;
		x = transform.position.x;
		addColors (new Color (24, 32, 133), new Color (253, 91, 16));
		addColors (new Color (0, 32, 133), new Color (253, 0, 16));
		//addColors (new Color (), new Color ());
		// create buttons
		foreach (List<Color> colors in this.colors) {
			createButton (colors);
		}
	}

	void createButton(List<Color> colors){

		Transform thisTrans = transform;
		thisTrans.position = new Vector2 (x, lasty);
		Debug.Log (thisTrans.position);
		
		GameObject go = Instantiate(button, thisTrans);
		(go.GetComponent<ButtonSelector> ()).colors = (colors);
		lasty -= inc;
	}	

	void addColors(Color c1, Color c2){
		List<Color> l = new List<Color> ();
		l.Add (c1);
		l.Add (c2);
		colors.Add (l);
	}
}
