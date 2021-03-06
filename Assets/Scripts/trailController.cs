﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class trailController : MonoBehaviour {

	GameObject[] enemies;
	public GameObject[] setPlayers; //must be set in inspector
	List<GameObject> players;
	List<GameObject[]> trails;
	List<bool> checkedTrails;
	public AudioClip pop;

	//List<GameObject> otherPlayersNodes;

	void Start(){
		Physics2D.IgnoreLayerCollision(8, 9, true);
		players = new List<GameObject>(setPlayers);
		trails = new List<GameObject[]>();
		//otherPlayersNodes = new List<GameObject>();
		checkedTrails = new List<bool>(new bool[] {false, false, false, false});


		StartCoroutine(delayStart());
	}

	// Update is called once per frame
	void Update () {


	}

	IEnumerator delayStart(){
		yield return new WaitForSeconds(1f);
		StartCoroutine(trailLoop ());
	}

	public IEnumerator trailLoop(){

		//every frame:

		for(int j = 0; j < players.Count; j++){
			players[j].GetComponent<trailMaker>().addNode(); //add node at head of trail
		}

		for(int i = 0; i < players.Count;){
			//Debug.Log ("i: " + i);
			if(checkedTrails[i]) { //skips over trails that have already been added into other trails.
				i++;
				continue;
			}
			trails.Add(players[i].GetComponent<trailMaker>().getTrail ());

			checkedTrails[i] = true;
			//i++; //increment i
			//head node is at index: trails[i].Length-1
			//for(int j = i; j < players.Length; j++){ 
			//	otherPlayersNodes.AddRange(players[j].GetComponent<trailMaker>().getTrail ()); //old method of checking every node that isnt this trail.
			//}

			//check to see if head near any other persons trail, if so stitch head of trail to tail of the near trail, repeat check as long as there are players.
			if(i < players.Count){
				//i++;
			}
			
			for(int j = 0; trails[i][trails[i].Length-1].GetComponent<nearNodes>().areOthersClose () && j < players.Count;){
				//Debug.Log ("YUH");
				//if(checkedTrails[j]) { //skips over trails that have already been added into other trails.


				//	j++;
					//continue;
				//}
				List<GameObject> tempTrail = new List<GameObject>();
				int indexOfFoundPlayer = players.IndexOf(trails[i][trails[i].Length-1].GetComponent<nearNodes>().whichOther ()); //searches for neighboring nodes of head of trail
				Debug.Log ("indexoffoundplayer: " + indexOfFoundPlayer);
				checkedTrails[indexOfFoundPlayer] = true; //mark trails that are completed as they are combined into main trail.
				tempTrail.AddRange(trails[i]);
				tempTrail.AddRange(players[indexOfFoundPlayer].GetComponent<trailMaker>().getTrail ());
				trails[i] = tempTrail.ToArray();
				j++;
			}
			
			for(int j = 0; j < players.Count; j++){ // set i to next unchecked trail.
				if(!checkedTrails[j]) {
					i = j; 
					break;
				}
			}
			
			
		}

		//for each isolated trail:
		for(int i = 0; i < trails.Count; i++){
			/*for(int j = 1; j < trails[i].Length; j++){
				Debug.DrawLine (trails[i][j-1].transform.position, trails[i][j].transform.position, Color.red, 0.1f, false);
			}*/
			enemies = GameObject.FindGameObjectsWithTag("enemy");
			for(int j = 0; j < enemies.Length; j++) {
				if(poly.ContainsPoint(trails[i], enemies[j].transform.position, trails[i][0].transform.parent.GetComponent<Owner>().getOwner())) {//check if enemy is inside polygon
					//ene.GetComponent<Health>().hurt(trailDamage); //destroy enemy inside polygon CAUSES MULTIPLE ENEMIES TO SPAWN
					GetComponent<AudioSource>().PlayOneShot(pop);//play pop noise
					Destroy(enemies[j]);
					Camera.main.GetComponent<EnemySpawner>().spawn(); //spawn new enemy 
				}
			}
		}

		yield return new WaitForSeconds(.1f);

		for(int i = 0; i < players.Count; i++){ //tell each player to remove the tail node
			players[i].GetComponent<trailMaker>().removeNode();
		}
		trails.Clear();
		checkedTrails.Clear ();
		checkedTrails = new List<bool>(new bool[] {false, false, false, false});

		StartCoroutine(trailLoop ());

		//do polygon check on each trail
		//if passes, check if head near tail and if so deal damage
		//set all trails back to false
		//NEEDS TO DRAW LINE ALONG WHOLE CREATED POLYGON
	}
}
