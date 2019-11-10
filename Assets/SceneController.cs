using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// p66

public class SceneController : MonoBehaviour {
	[SerializeField] private GameObject enemyPrefab; //serialized var for linking to the prefab (p66)
	private GameObject _enemy;

	void Update () {
		if (_enemy == null) { // spawn if none in scene 
			_enemy = Instantiate (enemyPrefab) as GameObject; // this method copies the prefab (p66)
			_enemy.transform.position = new Vector3(-10,-1.8f,0);
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);
		}
	}
}
