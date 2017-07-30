using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static EnemyManager enemyManager;
	private static LightManager lightManager;
	private static UIManager uiManager;
	public static int timeSurvived = 0;
	public static int numOfCompletedGames = 0;

	public bool isGameOver = true;

	public int GetNumOfGames() {
		return numOfCompletedGames;
	}

	public float GetTimeSurvived() {
		return timeSurvived;
	}

	public void SetNumOfGames(int num) {
		timeSurvived = num;
	}

	void Awake () {
		enemyManager = GetComponent<EnemyManager>();
		lightManager = GetComponent<LightManager>();
		uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
	}

	void Start () {
		isGameOver = false;
		var lightTimer = LightTimer();
		var gameTimer = GameTimer();
		StartCoroutine(lightTimer);
		StartCoroutine(gameTimer);
	}

	// Game LightTimer for triggering lights
	IEnumerator LightTimer () {
		Debug.Log("---START GAME---");
		while (!isGameOver) {
			yield return new WaitForSeconds(6.0f);
			lightManager.ChangeLights();
			yield return new WaitForSeconds(6.0f);
			lightManager.ChangeLights();
		}
		Debug.Log("---END GAME---");
	}

	IEnumerator GameTimer () {
		while (!isGameOver) {
			yield return new WaitForSeconds(1);
			timeSurvived++;
			uiManager.UpdateTimer(timeSurvived);
		}
	}

	public EnemyManager GetEnemyManager () {
		return enemyManager;
	}

	public LightManager GetLightManager () {
		return lightManager;
	}

	public UIManager GetUIManager () {
		return uiManager;
	}
}
