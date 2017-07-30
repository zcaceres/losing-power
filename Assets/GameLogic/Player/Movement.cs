using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour {
    public float speed = 3.0f;
    public float rotateSpeed = 100f;
		CharacterController controller;
    private Animator anim;

		void Awake() {
			controller = GetComponent<CharacterController>();
      anim = GetComponent<Animator>();
		}

    void Update() {
      float translation = Input.GetAxis("Vertical") * speed;
      float rotation = Input.GetAxis("Horizontal") * rotateSpeed;
      translation *= Time.deltaTime;
      rotation *= Time.deltaTime;
      transform.Translate(0, 0, translation);
      transform.Rotate(0, rotation, 0);

      if (translation != 0) {
        anim.SetBool("isMoving", true);
      } else {
        anim.SetBool("isMoving", false);
      }
        // transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        // Vector3 forward = transform.TransformDirection(Vector3.forward);
        // float curSpeed = speed * Input.GetAxis("Vertical");
        // controller.SimpleMove(forward * curSpeed);

    }
}
