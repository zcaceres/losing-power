using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent agent;
	private bool lit;
	private bool shouldWander;
	private static LightManager lm;
	private static GameObject[] lights;

	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		lm = GameObject.FindWithTag("GameController").GetComponent<GameManager>().GetLightManager();
		lights = lm.GetAllLights();
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
		int ind;
		if(agent.destination == null || agent.remainingDistance <= 0) {
			do {
				ind = Random.Range(0,lights.Length-1);
			} while (lights[ind].GetComponent<FlashlightController>().IsLightOn());
			agent.destination = lights[ind].transform.position;
		}
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
