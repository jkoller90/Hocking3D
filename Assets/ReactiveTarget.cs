using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour {

	public void ReactToHit() {
		StartCoroutine (Die ());
	}

	private IEnumerator Die(){
		this.transform.Rotate (-75, 0, 0); // makes enemy tip over
													// AKA gameObject.transform.Rotate(x,y,z);
		yield return new WaitForSeconds (1.5f);
		Destroy (this.gameObject);
	}
}
