// ﻿using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class MenuFlicker : MonoBehaviour {
//
//
// 	void Start () {
// 		isOn = !isOn;
// 		var flicker = Flicker();
// 		StartCoroutine(flicker);
// 		lightSound.Play();
// 	}
//
// 	// Creates flicker effect
// 	IEnumerator Flicker () {
// 		EnableLight(isOn);
// 		lightSound.Play();
// 		yield return new WaitForSeconds(Random.Range(0, 0.3f));
// 		EnableLight(!isOn);
// 		yield return new WaitForSeconds(Random.Range(0, 0.1f));
// 		EnableLight(isOn);
// 		yield return new WaitForSeconds(Random.Range(0, 0.3f));
// 		EnableLight(!isOn);
// 		yield return new WaitForSeconds(Random.Range(0, 0.3f));
// 		EnableLight(isOn);
// 		yield return new WaitForSeconds(Random.Range(0, 0.1f));
// 		EnableLight(!isOn);
// 		yield return new WaitForSeconds(0.2f);
// 		EnableLight(isOn);
// 		EnableLightTrigger(isOn);
// 		ToggleNavObstacle(isOn);
// 	}
// }
