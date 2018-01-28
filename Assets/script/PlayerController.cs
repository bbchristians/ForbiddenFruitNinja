using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text score;
	public Text gameOver;
	public string gameOverText;

	public Text[] lifeLabels;

	public Color emptyLifeColor = Color.black;

	public bool hasLost = false;

	public GameObject blade;

	public GameObject gameOverFade;
	public float gameOverAlpha = .1f;
	public float fadeDurationSec = 4f;


	private int lives = 3;
	private int points = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		score.text = points.ToString();
		if (lives <= 0 && !hasLost) {
			gameOver.text = gameOverText;
			hasLost = true;
			Destroy (blade);
			StartCoroutine (fadeAlpha (gameOverAlpha, fadeDurationSec));
		}
	}

	public void addScore(int points) {
		this.points += points;
	}

	public void loseLife() {
		if (lives > 0) {
			lives--;
			lifeLabels [lives].color = emptyLifeColor;
		}
	}

	IEnumerator fadeAlpha(float targetAlpha, float duration) {
		float alpha = gameOverFade.GetComponent<Image> ().color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / duration) {
			Color newColor = new Color (1, 1, 1, Mathf.Lerp (alpha, targetAlpha, t));
			gameOverFade.GetComponent<Image> ().color = newColor;
			yield return null;
		}
	}
}
