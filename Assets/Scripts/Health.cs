using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float maxHealth = 3;
	[HideInInspector]public float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;	
	}

	public float health(){
		return currentHealth;
	}
	
	public void hurt(float damage){
		currentHealth -= damage;
		if(currentHealth <= 0){
			Debug.Log (gameObject.name + " died!");

			//Destroy(gameObject);
		}
	}
}
