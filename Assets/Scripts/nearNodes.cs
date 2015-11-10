using UnityEngine;
using System.Collections;

public class nearNodes : MonoBehaviour{
	public LayerMask nodeLayer;
	public float searchRange = .01f;
	public bool isClose(GameObject tailNode) { //takes in a node and searches for nodes near it within a radius. if it finds one it returns true.
		//Debug.Log (transform.position + " " + tailNode.transform.position);
		//if(Physics2D.OverlapCircle(transform.position, searchRange, nodeLayer)){
		float dist = Vector2.Distance(transform.position, tailNode.transform.position);
		//Debug.Log (dist);
		if(dist < searchRange){
			Debug.Log (dist + " worked");
			return true;
		}
		return false;
	}
}
