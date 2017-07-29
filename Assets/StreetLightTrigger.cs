using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightTrigger : LightTrigger {
		private EnemyManager enemyManager;

		void Awake() {
			enemyManager = GameObject.FindWithTag("GameController")
				.GetComponent<GameManager>().GetEnemyManager();
		}

		protected virtual void OnTriggerEnter (Collider other) {
			return;
		}


		protected override void OnTriggerExit (Collider other) {
			if (other.tag == "Player") {
				Debug.Log("Player left light");
				enemyManager.TurnOnPursuit();
			}
		}

		void OnTriggerStay (Collider other) {
			if (other.tag == "Player") {
				Debug.Log("Player inside light");
				enemyManager.ToggleWander();
			}
		}
}
