using UnityEngine;
using System.Collections;

public class Owner : MonoBehaviour {
	public GameObject playerOwner;
	public void setOwner(GameObject newOwner){playerOwner = newOwner;}
	public GameObject getOwner(){return playerOwner;}
}
