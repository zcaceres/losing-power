using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private GameObject defeatIndicator;
	private GameObject survivalTimer;
	private Text currentTime;
	private GameObject powerplantFixer;
	private Text battery;

	void Awake () {
		defeatIndicator = transform.Find("Defeat").gameObject;
		survivalTimer = transform.Find("SurvivalTimer").gameObject;
		currentTime = survivalTimer.transform.Find("Timer").GetComponent<Text>();
		powerplantFixer = transform.Find("PowerplantFixer").gameObject;
		battery = transform.Find("Battery/BatteryIndicator").gameObject.GetComponent<Text>();
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

	public void RenderBattery (float batteryRemaining) {
		battery.text = batteryRemaining.ToString("#0.0");
	}
}
