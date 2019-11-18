/*
	Scroll

	Author: Graeme Holliday
	Purpose: Interpolate camera movement to follow the player.
*/

using UnityEngine;

public class Scroll : MonoBehaviour {

	private GameObject player;
	private const float SPEED = 5.0f;

	/*
		Start

		Purpose: Initialize the data fields.
	*/
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	/*
		Update

		Purpose: Each frame, move the camera towards the player position by an amount based on the SPEED value.
	*/
	void Update() {
		float interpolation = SPEED * Time.deltaTime;

		Vector3 position = this.transform.position;
		position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x + 10f, interpolation);
		position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);

		this.transform.position = position;
	}
}