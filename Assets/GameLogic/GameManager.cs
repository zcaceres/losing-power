using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static EnemyManager enemyManager;
	private static LightManager lightManager;
	public bool isGameOver = true;

	void Awake () {
		enemyManager = GetComponent<EnemyManager>();
		lightManager = GetComponent<LightManager>();
	}

	void Start () {
		isGameOver = false;
		var coroutine = Timer();
		StartCoroutine(coroutine);
	}

	// Game Timer for triggering lights
	IEnumerator Timer() {
		Debug.Log("---START GAME---");
		while (!isGameOver) {
			yield return new WaitForSeconds(6.0f);
			lightManager.ChangeLights();
			yield return new WaitForSeconds(6.0f);
			lightManager.ChangeLights();
		}
		Debug.Log("---END GAME---");
	}

	public EnemyManager GetEnemyManager() {
		return enemyManager;
	}

	public LightManager GetLightManager() {
		return lightManager;
	}
}
