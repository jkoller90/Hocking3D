using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	// Use this for initialization
	private CharacterController _charController;
	public float gravity = -9.8f;

	void Start () {
		_charController = GetComponent<CharacterController> (); //creates local reference to code object 
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed; //Horizontal and Vertical are names for keyboard mappings
		float deltaZ = Input.GetAxis ("Vertical") * speed; 

		//need a vector to pass into CharacterController.Move(Vector3)
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, speed);
		movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);


		_charController.Move (movement);

		transform.Translate (deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime); //frame independent, always checking for delta in key down
		// now the movement speed will be uniform across all machines
		//frame dependent would be transform.Translate(deltaX, 0, deltaZ);
		// deltaTime is time between frames: 30fps is a delta time of 1/30 of a second so multiplying the speed value by this will scale the speed per machine

	}




	/* 
	//  Primitive Floaty Movement
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed; //Horizontal and Vertical are names for keyboard mappings
		float deltaZ = Input.GetAxis ("Vertical") * speed; 

		//need a vector to pass into CharacterController.Move(Vector3)
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);

		movement *= Time.deltaTime;
		movement = transform.TransformDirection (movement);
		_charController.Move (movement);

		transform.Translate (deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime); //frame independent, always checking for delta in key down
		// now the movement speed will be uniform across all machines
		//frame dependent would be transform.Translate(deltaX, 0, deltaZ);
		// deltaTime is time between frames: 30fps is a delta time of 1/30 of a second so multiplying the speed value by this will scale the speed per machine

	}
	*/
}
