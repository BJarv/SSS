using UnityEngine;
using System.Collections;

public class nearNodes : MonoBehaviour{
	public LayerMask nodeLayer;
	public float searchRange = .01f;
	public bool isClose(GameObject tailNode) { //takes in a node and checks to make sure it is within range of this node that isClose is being called on
		//Debug.Log (transform.position + " " + tailNode.transform.position);
		//if(Physics2D.OverlapCircle(transform.position, searchRange, nodeLayer)){
		float dist = Vector2.Distance(transform.position, tailNode.transform.position);
		//Debug.Log (dist);
		if(dist < searchRange){
			return true;
		}
		return false;
	}

	public bool isClose(GameObject[] tailNodes) { //takes in a set of nodes, and check to see if the first half of them are close to this node
		float dist = 100f;
		for(int i = 0; i < tailNodes.Length/2; i++){
			dist = Vector2.Distance(transform.position, tailNodes[i].transform.position);
			if(dist < searchRange){ //first node it finds within the search range, return true
				return true;
			}
		}
		return false;
	}
}
