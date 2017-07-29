using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
	protected bool isOn = true;
	protected GameObject lightTrigger;
	protected GameObject lightSFX;
	protected EnemyManager enemyManager;

	void Awake () {
		// Get child components of Flashlight prefab
		lightTrigger = transform.Find("LightTrigger").gameObject;
		lightSFX = transform.Find("Light").gameObject;
	}

	void Start () {
		enemyManager = GameObject.FindWithTag("GameController")
			.GetComponent<GameManager>().GetEnemyManager();
	}

	/* We only expose this function to other classes to propagate
	 flashlight state down to the 'trigger' collider and light SFX
	 (helper functions below) */
	public virtual void ToggleLight () {
		isOn = !isOn;
		if (!isOn) {
			enemyManager.ReactivateEnemies();
		}
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	protected void EnableLightTrigger (bool isOn) {
		lightTrigger.SetActive(isOn);
	}

	protected void EnableLight (bool isOn) {
		lightSFX.SetActive(isOn);
	}

}
