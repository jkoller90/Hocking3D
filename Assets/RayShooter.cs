using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ** attach to camera not player
// ** attach to camera not player
// ** attach to camera not player
// ** attach to camera not player

public class RayShooter : MonoBehaviour {
	private Camera _camera;

	void Start () {
		_camera = GetComponent<Camera> (); //get all comps attached to camera

		// hide mouse cursor
		Cursor.lockState = CursorLockMode.Locked; 
		Cursor.visible = false; 
	}

	void OnGUI(){
		int size = 12;
		float posX = _camera.pixelWidth / 2 - size / 4;
		float posY = _camera.pixelHeight / 2 - size / 2;
		GUI.Label(new Rect(posX, posY, size, size), "*"); // "*" indicates its position in center of the screen
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 point = new Vector3 (_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0); // mid of screen is .5x its width and height
			Ray ray = _camera.ScreenPointToRay(point); // ray created at position point

			RaycastHit hit; //this reference variable will be filled with information
			if (Physics.Raycast (ray, out hit)){
				GameObject hitObject = hit.transform.gameObject; // retrieve object hit by the ray
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					Debug.Log ("Target hit at " + hit.point); //coordinates where the ray hit
					target.ReactToHit ();
				} else {
					StartCoroutine (SphereIndicator (hit.point));
				}
			}
		}	
	}

	private IEnumerator SphereIndicator(Vector3 pos){
		GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds (1); // yield tells coroutine where to pause
		Destroy (sphere);
	}
}
