using UnityEngine;

public class Scroll : MonoBehaviour {

	private GameObject player;
	private float speed = 5.0f;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {
		float interpolation = speed * Time.deltaTime;

		Vector3 position = this.transform.position;
		position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x + 10f, interpolation);
		position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, interpolation);

		this.transform.position = position;
	}
}