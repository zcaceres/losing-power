using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {
	static GameObject[] lights;

	public GameObject[] GetAllLights () {
		return GameObject.FindGameObjectsWithTag("Light");
	}

	void Awake () {
		lights = GetAllLights();
	}

	void Start () {
		var coroutine = Timer();
		StartCoroutine(coroutine);
	}

	IEnumerator Timer() {
		Debug.Log("starting timer");
		yield return new WaitForSeconds(2.0f);
		Debug.Log("ending timer");
		ChangeLights(lights);
		yield return new WaitForSeconds(2.0f);
		ChangeLights(lights);
	}

	void ChangeLights(GameObject[] lights) {
		for (var i = 0; i < lights.Length; i++) {
			var probability = Random.Range(0f, 1.0f);
			Debug.Log(probability);
			if (probability > 0.5f) {
				lights[i].GetComponent<FlashlightController>().ToggleLight();
			}
		}
	}

}
