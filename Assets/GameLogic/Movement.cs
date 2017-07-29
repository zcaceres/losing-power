using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
		CharacterController controller;

		void Awake() {
			controller = GetComponent<CharacterController>();
		}

    void Update() {
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);
    }
}
