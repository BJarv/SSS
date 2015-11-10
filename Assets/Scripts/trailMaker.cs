using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class trailMaker : MonoBehaviour {

	public GameObject trailObj;
	Queue<GameObject> trail;
	public GameObject[] enemies;
	public GameObject trailNode;
	GameObject trailContainer; //holds all trailnodes as children

	
	// Use this for initialization
	void Start () {
		trailContainer = (GameObject)Instantiate (trailObj, transform.position, Quaternion.identity); //instantiate trail object
		//trailContainer.transform.parent = transform; //set parent of trail to be player for organization sake
		initTrail(); //creates initial length of trail
		StartCoroutine(trailLoop()); //start trail loop

	}

	void FixedUpdate () {

	}
	
	void initTrail(){ //builds up a length of trail to follow behind the player PROBABLY NEEDS A VISUAL NODE?
		trail = new Queue<GameObject>();
		for(int i = 0; i < 30; i++) {
			GameObject tempNode = (GameObject)Instantiate(trailNode, transform.position, Quaternion.identity);
			tempNode.transform.parent = trailContainer.transform;
			trail.Enqueue (tempNode);
		}
	}

	IEnumerator trailLoop(){ //main trail loop
		GameObject tempNode = (GameObject)Instantiate(trailNode, transform.position, Quaternion.identity);
		tempNode.transform.parent = trailContainer.transform;
		trail.Enqueue (tempNode); //add a trail point to current location
		//test array of enemies for within trail, if they are inside, kill them
		foreach(GameObject ene in enemies) {
			if(poly.ContainsPoint(trail.ToArray(), ene.transform.position)) {//check if enemy is inside polygon
				Debug.Log ("Enemy Death");
			}
		}
		yield return new WaitForSeconds(.1f); //wait before removing old points and restarting coroutine.
		Destroy(trail.Dequeue()); //destroy trail node as you dequeue it.
		StartCoroutine(trailLoop ());

	}

}
