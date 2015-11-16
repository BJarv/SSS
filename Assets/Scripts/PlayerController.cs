using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public bool controllable = true;
	Rigidbody2D r;
	public float speed;
	public int playerNum;

	// Use this for initialization
	void Start () {
		if (playerNum == 0){
			Debug.LogError("set playernum for" + gameObject.name);
		}
		r = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		if(controllable){
			/*if(Input.GetAxis("Horizontal") > 0) { //right

			} else if (Input.GetAxis ("Horizontal") < 0) { //left

			}

			if(Input.GetAxis("Vertical") > 0) { //up
				
			} else if (Input.GetAxis ("Vertical") < 0) { //down
				
			}*/
			if(playerNum == 1){ //simple movement
				r.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical"));
			} else if (playerNum == 2){
				r.velocity = new Vector2(speed * Input.GetAxis("Horizontal2"), speed * Input.GetAxis("Vertical2"));
			}




		}
	}
}
