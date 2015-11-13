using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;
	GameObject[] spawns;

	void Start() {
		spawns = GameObject.FindGameObjectsWithTag("spawn");
	}

	public void spawn(){
		Instantiate(enemy, spawns[Random.Range(0, spawns.Length-1)].transform.position, Quaternion.identity);
	}

}
