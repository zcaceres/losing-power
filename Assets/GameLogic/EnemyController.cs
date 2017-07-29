using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent agent;
	private bool lit;
	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}


	void Start () {
		lit = false;
	}

	void FollowPlayer () {
		agent.destination = player.position;
	}

	void Stop () {
		agent.destination = agent.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (!lit) {
			FollowPlayer();
		} else {
			if (!agent.isStopped) {
				Stop();
			}
		}
	}
}
