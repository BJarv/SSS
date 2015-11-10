using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public bool controllable = true;
	Rigidbody2D r;
	public float speed;

	// Use this for initialization
	void Start () {

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
			r.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), speed * Input.GetAxis("Vertical")); //simple movement



		}
	}
}
