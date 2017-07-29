using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static EnemyManager enemyManager;
	private static LightManager lightManager;

	void Awake () {
		enemyManager = GetComponent<EnemyManager>();
		lightManager = GetComponent<LightManager>();
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public EnemyManager GetEnemyManager() {
		return enemyManager;
	}

	public LightManager GetLightManager() {
		return lightManager;
	}

}
