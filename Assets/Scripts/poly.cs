using UnityEngine;
using System.Collections;

public static class poly {

	public static bool ContainsPoint(GameObject[] polyPoints, Vector2 p, GameObject trailOwner){ //checks if a point is inside the shape given by the array of points

		bool inside = false;
		int n = polyPoints.Length - 1;

		for(int i = 0; i < polyPoints.Length; n = i++) {
			if(polyPoints[i] == null){continue;}
			if ( ((polyPoints[i].transform.position.y <= p.y && p.y < polyPoints[n].transform.position.y) || (polyPoints[n].transform.position.y <= p.y && p.y < polyPoints[i].transform.position.y)) && 
			    (p.x < (polyPoints[n].transform.position.x - polyPoints[i].transform.position.x) * (p.y - polyPoints[i].transform.position.y) / (polyPoints[n].transform.position.y - polyPoints[i].transform.position.y) + polyPoints[i].transform.position.x))
				inside = !inside;
				
		}
		if(inside && !polyPoints[polyPoints.Length-1].GetComponent<nearNodes>().isCloseSelf(polyPoints)) { //hotfix check to make sure that the tail and head of the trail are near each other
			inside = !inside; //if the tail isnt near the head, fail the check.
		}

		for(int i = 1; i < polyPoints.Length; i++){
			if(inside){
				Debug.DrawLine (new Vector3(polyPoints[i-1].transform.position.x, polyPoints[i-1].transform.position.y, polyPoints[i-1].transform.position.z - 1), new Vector3(polyPoints[i].transform.position.x, polyPoints[i].transform.position.y, polyPoints[i].transform.position.z - 1), Color.green, 3f, false);
			} else {
				Debug.DrawLine (new Vector3(polyPoints[i-1].transform.position.x, polyPoints[i-1].transform.position.y, polyPoints[i-1].transform.position.z), new Vector3(polyPoints[i].transform.position.x, polyPoints[i].transform.position.y, polyPoints[i].transform.position.z), Color.red, .1f, true);
			}
		}
		if(inside){
			Debug.DrawLine (new Vector3(polyPoints[polyPoints.Length-1].transform.position.x, polyPoints[polyPoints.Length-1].transform.position.y, polyPoints[polyPoints.Length-1].transform.position.z - 1), new Vector3(trailOwner.transform.position.x, trailOwner.transform.position.y, trailOwner.transform.position.z - 1), Color.green, 3f, false);
		}
		return inside;
	}
}

/*
 * 
 * 
 * 
 * public static bool ContainsPoint(Vector2[] polyPoints, Vector2 p){ //vector2 version
		bool inside = false;
		int n = polyPoints.Length - 1;
		for(int i = 0; i < polyPoints.Length; n = i++) {
			if ( ((polyPoints[i].y <= p.y && p.y < polyPoints[n].y) || (polyPoints[n].y <= p.y && p.y < polyPoints[i].y)) && 
			    (p.x < (polyPoints[n].x - polyPoints[i].x) * (p.y - polyPoints[i].y) / (polyPoints[n].y - polyPoints[i].y) + polyPoints[i].x)) 
				inside = !inside; 
		}



		return inside;
	}

 */