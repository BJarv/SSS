using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerhealthdisplay : MonoBehaviour {

	public GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		Debug.Log (player.GetComponent<Health>().currentHealth);
		GetComponent<Text>().text = "Player Health: " + player.GetComponent<Health>().health ();
	}
}
