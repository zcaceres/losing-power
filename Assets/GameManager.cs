using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private static EnemyManager enemyManager;

	void Awake () {
		enemyManager = GetComponent<EnemyManager>();
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

}
