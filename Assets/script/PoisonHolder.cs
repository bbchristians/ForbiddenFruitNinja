using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHolder : MonoBehaviour {

	public List<List<Color>> colors;

	public void addColor(List<Color> colors) {
		this.colors.Add(colors);
		return;
	}
}
