using UnityEngine;
using System.Collections;

public class nearNodes : MonoBehaviour{
	public LayerMask nodeLayer;
	public float searchRange = .5f;
	GameObject playerNearNode; //player that is identified with areOthersClose
	Collider2D[] othersNearNodes; //filled in areOthersClose, nodes that are near to this node that dont belong to same trail

	void Start() {
		//othersNearNodes = new Collider2D[];
	}

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

	public bool isClose(GameObject[] tailNodes) { //takes in a set of nodes, and check to see ANY of them are close to this node
		float dist = .5f;
		for(int i = 0; i < tailNodes.Length; i++){
			dist = Vector2.Distance(transform.position, tailNodes[i].transform.position);
			if(dist < searchRange){ //first node it finds within the search range, return true
				return true;
			}
		}
		return false;
	}

	public bool isCloseSelf(GameObject[] tailNodes) { //takes in a set of nodes, and check to see if the FIRST HALF of them are close to this node
		float dist = .5f;
		for(int i = 0; i < tailNodes.Length/2; i++){
			dist = Vector2.Distance(transform.position, tailNodes[i].transform.position);
			if(dist < searchRange){ //first node it finds within the search range, return true
				return true;
			}
		}
		return false;
	}

	public bool areOthersClose(){ //returns true if there is a node near this one that doesnt belong to this trail
		othersNearNodes = Physics2D.OverlapCircleAll(transform.position, searchRange, nodeLayer);
		if(othersNearNodes.Length > 0){
		//if(Physics2D.OverlapCircleNonAlloc()(transform.position, searchRange, othersNearNodes, nodeLayer) > 0){ 
			for(int i = 0; i < othersNearNodes.Length; i++){
				if(othersNearNodes[i].transform.parent.GetComponent<Owner>().getOwner() != transform.parent.GetComponent<Owner>().getOwner ()){ //if found node is not from the same player, save which player.
					playerNearNode = othersNearNodes[i].transform.parent.GetComponent<Owner>().getOwner();
					Debug.Log ("near nodes not parents");
					return true;
				}
			}
		}
		return false;
	}

	public GameObject whichOther(){
		return playerNearNode;
	}

	//void OnDrawGizmos(){
	//	Gizmos.DrawWireSphere(transform.position, searchRange);
	//}

}
