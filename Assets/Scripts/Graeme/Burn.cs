using UnityEngine;

public class Burn : MonoBehaviour {

	public void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Player")
			Debug.Log("Ouch!");
	}

}
