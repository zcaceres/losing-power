using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent agent;
	private bool lit;
	private bool shouldWander;

	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	void Start () {
		lit = false;
	}

	public void GotLit (bool isLit) {
		lit = isLit;
	}

	void FollowPlayer () {
		agent.destination = player.position;
	}

	void Stop () {
		agent.destination = agent.transform.position;
	}

	public void ShouldWander (bool wander) {
		shouldWander = wander;
	}

	void Wander () {
		Debug.Log("I'm wandering");
	}

	void Update () {
		if (shouldWander) {
			Wander();
			return;
		}
		if (!lit) {
			FollowPlayer();
		} else {
			if (!agent.isStopped) {
				Stop();
			}
		}
	}
}
