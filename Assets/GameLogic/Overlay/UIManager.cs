using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private GameObject defeatIndicator;
	private GameObject survivalTimer;
	private Text currentTime;
	private GameObject powerplantFixer;

	void Awake () {
		defeatIndicator = transform.Find("Defeat").gameObject;
		survivalTimer = transform.Find("SurvivalTimer").gameObject;
		currentTime = survivalTimer.transform.Find("Timer").GetComponent<Text>();
		powerplantFixer = transform.Find("PowerplantFixer").gameObject;
	}

	// TODO TRIGGER WHEN COLLIDE WITH BADDIE
	public void ShowDefeat (bool toShow) {
		defeatIndicator.SetActive(toShow);
	}

	public void ShowSurvivalTimer (bool toShow) {
		survivalTimer.SetActive(toShow);
	}

	public void UpdateTimer (int time) {
		currentTime.text = time.ToString();
	}

	public void StartPowerplantGame () {
		powerplantFixer.SetActive(true);
	}

	public void StopPowerplaneGame () {
		powerplantFixer.SetActive(false);
	}
}

// 4.5 5.5
