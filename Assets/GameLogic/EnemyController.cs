using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent agent;

	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}


	void Start () {

	}

	// Update is called once per frame
	void Update () {
		agent.destination = player.position;
	}
}
