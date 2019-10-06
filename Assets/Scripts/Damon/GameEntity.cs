using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour
{
	new public Rigidbody2D rigidbody2D;
	protected Animator animator;
	protected Vector2 mapPosition;

	// Start is called before the first frame update
	public void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		// need to keep this entity facing upwards
		transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0), Vector3.up);
	}
}
