﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {


	Transform target;
	public float speed;	
	public float damage = 1f;
	// Use this for initialization
	void Start () {
		GameObject[] choose = GameObject.FindGameObjectsWithTag("Player");
		target = choose[Random.Range (0, choose.Length)].transform;
	}
	
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

	void OnTriggerEnter2D(Collider2D colObj){
		if(colObj.tag == "Player"){
			colObj.gameObject.GetComponent<Health>().hurt (damage);
		}
	}
}
