using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	private GameObject[] enemies;

	void Awake() {

	}

	void Start () {
		enemies = GetAllEnemies();
	}

	GameObject[] GetAllEnemies () {
		return GameObject.FindGameObjectsWithTag("Enemy");
	}

	public void ToggleWander () {
		for (var i = 0; i < enemies.Length; i++) {
			var controller = enemies[i].GetComponent<EnemyController>();
			controller.ShouldWander(true);
		}
	}

	public void TurnOnPursuit () {
		for (var i = 0; i < enemies.Length; i++) {
			var controller = enemies[i].GetComponent<EnemyController>();
			controller.ShouldWander(false);
		}
	}

}
