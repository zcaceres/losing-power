using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour {
	protected bool isOn = true;
	protected GameObject lightTrigger;
	protected GameObject lightSFX;
	protected EnemyManager enemyManager;
	protected AudioSource lightSound;

	void Awake () {
		// Get child components of Flashlight prefab
		lightTrigger = transform.Find("LightTrigger").gameObject;
		lightSFX = transform.Find("Light").gameObject;
		lightSound = GetComponent<AudioSource>();
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
		lightSound.Play();
		EnableLightTrigger(isOn);
		EnableLight(isOn);
	}

	protected void EnableLightTrigger (bool isOn) {
		if (isOn) {
			lightTrigger.transform.position = new Vector3(lightTrigger.transform.position.x,
																							0,lightTrigger.transform.position.z);
		} else {
			lightTrigger.transform.position = new Vector3(lightTrigger.transform.position.x,
																							9,lightTrigger.transform.position.z);
		}

		// lightTrigger.SetActive(isOn);
	}

	protected void EnableLight (bool isOn) {
		lightSFX.SetActive(isOn);
	}

}
