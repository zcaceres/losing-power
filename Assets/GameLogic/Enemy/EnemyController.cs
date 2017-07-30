using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	private Transform player;
	private UnityEngine.AI.NavMeshAgent agent;
	private bool lit;
	private bool shouldWander;
	private const int WALK_RADIUS = 50;
	private UnityEngine.AI.NavMeshPath path;


	void Awake () {
		player = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		path = new UnityEngine.AI.NavMeshPath();
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
		if(!shouldWander){
			FollowPlayer();
		}
	}

	void Wander () {
		bool reachedDestination = false;
		if (!agent.pathPending) {
				if (agent.remainingDistance <= agent.stoppingDistance) {
						if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
							reachedDestination = true;
						}
				}
		}

		float dist = Vector3.Distance(agent.destination,player.position);

		if(dist < 10.0f || reachedDestination) {
			Vector3 randomLocation;
			do {
				randomLocation = Random.insideUnitSphere * WALK_RADIUS;
				randomLocation.y = 0;
			} while(!UnityEngine.AI.NavMesh.CalculatePath(transform.position,
							randomLocation,UnityEngine.AI.NavMesh.AllAreas,path));

			agent.destination = randomLocation;
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
