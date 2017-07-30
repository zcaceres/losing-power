using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerplantMinigame : MonoBehaviour {
	private bool isStarted;
	private Slider slider;
	private bool increment;
	const int TIME_MULTIPLIER = 15;
	private GameManager gameManager;

	void Awake () {
		slider = transform.Find("Slider").GetComponent<Slider>();
		gameManager = GameObject.FindWithTag("GameController")
		.GetComponent<GameManager>();
	}

	void OnEnable () {
		isStarted = true;
		increment = true;
	}

	void OnDisable () {
		isStarted = false;
	}

	void CheckPosition (float val) {
		if (val >= 0.45f && val <= 0.55f) {
			Win();
		} else {
			Lose();
		}
	}

	void Win () {
		var currNum = gameManager.GetNumOfGames();
		gameManager.SetNumOfGames(++currNum);
	}

	void Lose () {
		var currNum = gameManager.GetNumOfGames();
		gameManager.SetNumOfGames(--currNum);
	}

	void CheckIfAtOneOrZero(float val) {
		if (val >= 1f) {
			increment = false;
		} else if (val <= 0f) {
			increment = true;
		}
		return;
	}

	void CycleSlider () {
		CheckIfAtOneOrZero(slider.value);
		if (increment) {
			slider.value += 0.1f * Time.deltaTime * TIME_MULTIPLIER;
		} else {
			slider.value -= 0.1f * Time.deltaTime * TIME_MULTIPLIER;
		}
	}

	void Update () {
		if (!isStarted) {
			return;
		}

		CycleSlider();
		if (Input.GetMouseButtonDown(0)) {
			CheckPosition(slider.value);
		}
	}
}
