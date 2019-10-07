using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntity : MonoBehaviour
{
	protected Rigidbody2D rigidbody2D;
	protected Animator animator;
	protected Vector2 mapPosition;

	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
}
