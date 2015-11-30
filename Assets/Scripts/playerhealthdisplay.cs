using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerhealthdisplay : MonoBehaviour {

	//public GameObject player;
	public float health = 3f;
	bool inPlay = true;

	void Start(){
		//player = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log (player.GetComponent<Health>().currentHealth);
		if(inPlay){ //if players havent lost yet, display health
			GetComponent<Text>().text = "Health: " + health;
		} else {
			GetComponent<Text>().text = "YOU LOSE!!!";
		}

	}

	public void hurt(){
		health -= 1f;
		if(health <= 0){
			inPlay = false;
		}
	}
}
