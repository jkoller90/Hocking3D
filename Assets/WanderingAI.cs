using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
	public float speed = 3.0f;
	public float obstacleRange = 5.0f;

	private bool _alive; //pp63

	void start(){
		_alive = true; // pp63
	}

	// Update is called once per frame
	void Update () {
		_alive = true;
		if (_alive) { // p63
			transform.Translate (0, 0, speed * Time.deltaTime); // move forward continuously each frame w/o/r/t turning [pp62]
		}

		Ray ray = new Ray (transform.position, transform.forward); // ray at same position and pointing at same direction, at character [pp62] 
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.75f, out hit)) { //do raycasting w/ circumference around the ray (p62)
			if (hit.distance < obstacleRange) {
				float angle = Random.Range(-110,110); //occassionally turn toward semi random new direction (p62)
				transform.Rotate (0, angle, 0); 
			}
		}
	}

	public void SetAlive(bool alive){ //63
		_alive = alive; //63
	}

	public void ReactToHit(){
		WanderingAI behavior = GetComponent<WanderingAI> (); //access other comps attached to the object
		if (behavior != null) {
			behavior.SetAlive (false);
		}
		//StartCoroutine (Die ());
		Destroy(this); 
	}

}
