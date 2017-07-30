using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLightTrigger : LightTrigger {
		public EnemyManager enemyManager;

		// TODO Make awake method

		protected override void OnTriggerEnter (Collider other) {
			return;
		}


		protected override void OnTriggerExit (Collider other) {
			if (other.tag == "Player") {
				enemyManager.TurnOnPursuit();
			}
		}

		void OnTriggerStay (Collider other) {
			if (other.tag == "Player") {
				enemyManager.ToggleWander();
			}
		}
}
