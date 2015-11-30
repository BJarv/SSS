using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	Transform target;
	public float speed;	
	public float damage = 1f;
	// Use this for initialization
	public playerhealthdisplay health;

	void Start () {
		health = GameObject.Find ("Canvas/Text").GetComponent<playerhealthdisplay>();
		GameObject[] choose = GameObject.FindGameObjectsWithTag("Player");
		target = choose[Random.Range (0, choose.Length)].transform;
	}
	
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

	void OnTriggerEnter2D(Collider2D colObj){
		if(colObj.tag == "Player"){
			health.hurt ();
		}
	}
}
