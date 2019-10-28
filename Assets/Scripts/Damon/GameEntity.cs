using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
	new public Rigidbody2D rigidbody2D;
	private Animator animator;
	protected Collider2D collider2D;
	protected SpriteRenderer renderer;
	private Vector2 spawnPosition;
	private float maxSpeed = 100;
	private float maxHorizontalSpeed = 50;
	private float accel = 10;
	private float deaccel = 5;
	private float jumpForce = 6;
	private bool accelerate = false;


	public GameEntity()
	{
		maxSpeed = 10;
		accel = 10;
		deaccel = 5;
		jumpForce = 6;
	}

	// Start is called before the first frame update
	public void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		collider2D = GetComponent<Collider2D>();
		renderer = GetComponent<SpriteRenderer>();
		spawnPosition = transform.position;
	}

	public void Update()
	{
		// Checking the maximum speed of this entity
		if (rigidbody2D.velocity.magnitude > maxSpeed)
		{
			// Then we need to normalize this vector
			//rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
		}

		// if we have not moved in any direction, then we deaccelerate
		if(!accelerate)
			//Deaccelerate();

		accelerate = false;
	}

	//
	// deprecated function
	//
	//
	public void Accelerate(Vector2 vector)
	{
		vector = Vector2.ClampMagnitude(vector, accel);
		// Then add the vector to the current velocity vector
		// but first verfiy that we are not adding past our max speed
		if((rigidbody2D.velocity + vector).magnitude < maxSpeed)
			rigidbody2D.velocity += vector;

		accelerate = true;
	}

	public void MoveLeft()
	{
		rigidbody2D.velocity = new Vector2(-maxHorizontalSpeed, rigidbody2D.velocity.y);
		accelerate = true;

	}

	public void MoveRight()
	{
		rigidbody2D.velocity = new Vector2(maxHorizontalSpeed, rigidbody2D.velocity.y);
		
		accelerate = true;

	}

	private void Deaccelerate()
	{
		Vector2 currentVelocity = rigidbody2D.velocity;
		float magnitude = currentVelocity.magnitude;
		rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, magnitude - Deaccel);
	}

	public void Jump()
	{
		if (IsGrounded() && rigidbody2D.velocity.y == 0.0f)
		{
			//rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			rigidbody2D.velocity += new Vector2(0, 10);
		}
	}

	public void ShiftUp()
	{
		//rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		transform.Translate(0, 1, 0);
	}

	public bool IsGrounded()
	{
		return Physics2D.Raycast(transform.position, -Vector3.up, 0.01f) || 
			Physics2D.Raycast(new Vector3(transform.position.x + renderer.size.x, transform.position.y, transform.position.z), -Vector3.up, 0.01f);
	}

	public Vector2 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
	public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
	public float Accel { get => accel; set => accel = value; }
	public float JumpForce { get => jumpForce; set => jumpForce = value; }
	public float Deaccel { get => deaccel; set => deaccel = value; }
	public float MaxHorizontalSpeed { get => maxHorizontalSpeed; set => maxHorizontalSpeed = value; }
	public Animator Animator { get => animator; set => animator = value; }
}
