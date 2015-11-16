using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class trailController : MonoBehaviour {

	GameObject[] enemies;
	public GameObject[] setPlayers; //must be set in inspector
	List<GameObject> players;
	List<GameObject[]> trails;
	List<bool> checkedTrails;

	//List<GameObject> otherPlayersNodes;

	void Start(){
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

		for(int i = 0; i < players.Count; i++){
			players[i].GetComponent<trailMaker>().addNode();
		}

		for(int i = 0; i < players.Count;){
			if(checkedTrails[i]) { //skips over trails that have already been added into other trails.
				i++;
				continue;
			}
			trails.Add(players[0].GetComponent<trailMaker>().getTrail ());

			checkedTrails[i] = true;
			//i++; //increment i
			//head node is at index: trails[i].Length-1
			//for(int j = i; j < players.Length; j++){ 
			//	otherPlayersNodes.AddRange(players[j].GetComponent<trailMaker>().getTrail ()); //old method of checking every node that isnt this trail.
			//}

			//check to see if head near any other persons trail, if so stitch head of trail to tail of the near trail, repeat check as long as there are players.
			while(trails[i][trails[i].Length-1].GetComponent<nearNodes>().areOthersClose ()){
				if(checkedTrails[i]) { //skips over trails that have already been added into other trails.
					i++;
					continue;
				}
				List<GameObject> tempTrail = new List<GameObject>();
				int indexOfFoundPlayer = players.BinarySearch(trails[i][trails[i].Length-1].GetComponent<nearNodes>().whichOther ());
				checkedTrails[indexOfFoundPlayer] = true; //mark trails that are completed as they are combined into main trail.
				tempTrail.AddRange(trails[i]);
				tempTrail.AddRange(trails[indexOfFoundPlayer]);
				trails[i] = tempTrail.ToArray();
				i++;
			}
			
			
		}

		//for each isolated trail:
		for(int i = 0; i < trails.Count; i++){
			enemies = GameObject.FindGameObjectsWithTag("enemy");
			foreach(GameObject ene in enemies) {
				if(poly.ContainsPoint(trails[i], ene.transform.position)) {//check if enemy is inside polygon
					//ene.GetComponent<Health>().hurt(trailDamage); //destroy enemy inside polygon CAUSES MULTIPLE ENEMIES TO SPAWN
					Destroy(ene);
					Camera.main.GetComponent<EnemySpawner>().spawn(); //spawn new enemy
				}
			}
		}

		yield return new WaitForSeconds(.1f);

		for(int i = 0; i < players.Count; i++){
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
