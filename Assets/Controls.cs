﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	void Start () {

	}

	void Update () {
			if (Input.GetMouseButtonDown(0)) {
				var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit)) {
					Debug.Log(ray + " " + hit.transform);
				}
			}
	}
}
