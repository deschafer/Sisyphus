/*
	Burn

	Author: Graeme Holliday
	Purpose: Attached to a GameObject, this script gradually does damage to the player while the player remains in contact with it.
*/

using UnityEngine;

public class Burn : MonoBehaviour {

	/*
		OnTriggerStay2D

		Parameters: Collider of the object within this object's collider.
		Purpose: If the object within is the player, do damage to it slowly over time.
	*/
	public void OnTriggerStay2D(Collider2D other) {
		//TODO: Actually damage the player. Relies on @Max making a damagePlayer() function of some sort.
		if(other.gameObject.tag == "Player")
			Debug.Log("Ouch!");
	}

}
