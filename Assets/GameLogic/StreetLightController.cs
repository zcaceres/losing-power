using System.Collections;
using System.Collections.Generic;


public class StreetLightController : FlashlightController {
	private UnityEngine.AI.NavMeshObstacle obstacle;


	void Start () {
		obstacle = lightTrigger.GetComponent<UnityEngine.AI.NavMeshObstacle>();
	}

	public override void ToggleLight () {
		isOn = !isOn;
		base.EnableLightTrigger(isOn);
		base.EnableLight(isOn);
	}

	private void ToggleNavObstacle () {
		obstacle.enabled = isOn;
	}
}
