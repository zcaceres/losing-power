using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
	private static float batteryRemaining = 100f;
	const int DRAIN_MULTIPLIER = 30;
	protected bool isOn = true;
	protected GameObject lightTrigger;
	protected GameObject lightSFX;
	protected EnemyManager enemyManager;
	protected UIManager uiManager;
	protected AudioSource lightSound;
	bool drainBattery;

	void Awake () {
		// Get child components of Flashlight prefab
		lightTrigger = transform.Find("LightTrigger").gameObject;
		lightSFX = transform.Find("Light").gameObject;
		lightSound = GetComponent<AudioSource>();
		uiManager = GameObject.FindWithTag("GameController")
		.GetComponent<GameManager>().GetUIManager();
		enemyManager = GameObject.FindWithTag("GameController")
		.GetComponent<GameManager>().GetEnemyManager();
	}

	void Start () {
		lightSFX.SetActive(false);
		ForceLightOff();
	}

	public void RefillBattery () {
		batteryRemaining = 100f;
	}

	/* We only expose this function to other classes to propagate
	 flashlight state down to the 'trigger' collider and light SFX
	 (helper functions below) */
	public virtual void ToggleLight () {
		if (batteryRemaining <= 0) {
			return;
		}
		isOn = !isOn;
		if (!isOn) {
			enemyManager.ReactivateEnemies();
			drainBattery = false;
		} else {
			drainBattery = true;
		}
		lightSound.Play();
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	void ForceLightOff() {
		isOn = false;
		if(enemyManager == null) {
			enemyManager = GameObject.FindWithTag("GameController")
			.GetComponent<GameManager>().GetEnemyManager();
		}
		enemyManager.ReactivateEnemies();
		drainBattery = false;
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	void Update() {
		if (uiManager == null) {
			uiManager = GameObject.FindWithTag("GameController")
			.GetComponent<GameManager>().GetUIManager();
		} else {
			uiManager.RenderBattery(batteryRemaining);
		}
		if (drainBattery) {
			batteryRemaining -= 0.1f * Time.deltaTime * DRAIN_MULTIPLIER;
			if (batteryRemaining <= 0) {
				ForceLightOff();
			}
		}
	}

	protected void EnableLightTrigger (bool isOn) {
		var baseVal = new Vector3(lightTrigger.transform.position.x, 0, lightTrigger.transform.position.z);
		var highVal = new Vector3(lightTrigger.transform.position.x, 9, lightTrigger.transform.position.z);
		lightTrigger.SetActive(true);
		if (isOn) {
			lightTrigger.transform.position = baseVal;
		} else {
			lightTrigger.transform.position = highVal;
		}
	}

	protected void EnableLight (bool isOn) {
		lightSFX.SetActive(isOn);
	}

}
