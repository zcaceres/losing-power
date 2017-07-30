using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
	static GameObject[] lights;
	static GameManager gameManager;
	const float BASE_PROBABILITY = 0.5f;
	float currentProbability = BASE_PROBABILITY;

	GameObject[] GetAllLights () {
		return GameObject.FindGameObjectsWithTag("Light");
	}

	float ComputeCurrentProbability () {
		float prob = BASE_PROBABILITY + (gameManager.GetNumOfGames() * 0.1f) - ((gameManager.GetTimeSurvived() / 60) * 0.1f);
		return prob <= 0 ? 0.1f : prob;
	}


	void Awake () {
		lights = GetAllLights();
		gameManager = GameObject.FindWithTag("GameController")
		.GetComponent<GameManager>();
	}

	public void ChangeLights() {
		var prob = ComputeCurrentProbability();
		Debug.Log("current prob " + prob);
		for (var i = 0; i < lights.Length; i++) {
			var probability = Random.Range(0f, 1.0f);
			if (probability > prob) {
				lights[i].GetComponent<FlashlightController>().ToggleLight();
			}
		}
	}
}
