using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
	new public Rigidbody2D rigidbody2D;
	protected Animator animator;
	protected Collider2D collider2D;
	private Vector2 spawnPosition;
	private float maxSpeed = 100;
	private float accel = 10;
	private float deaccel = 5;
	private float jumpForce = 6;
	private float distanceToGround = 0;

	public GameEntity()
	{
		maxSpeed = 100;
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
	}

	public void Update()
	{
		// need to keep this entity facing upwards
		transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0), Vector3.up);

		// Get the distances until the ground
		distanceToGround = collider2D.bounds.extents.y;

		// Checking the maximum speed of this entity
		if (rigidbody2D.velocity.magnitude > maxSpeed)
		{
			// Then we need to normalize this vector
			rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
		}

		Deaccelerate();
	}

	public void Accelerate(Vector2 vector)
	{
		vector = Vector2.ClampMagnitude(vector, accel);
		// Then add the vector to the current velocity vector
		rigidbody2D.velocity += vector;
	}

	private void Deaccelerate()
	{
		Vector2 currentVelocity = rigidbody2D.velocity;
		float magnitude = currentVelocity.magnitude;
		rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, magnitude - Deaccel);
	}

	public void Jump()
	{
		if (IsGrounded())
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public bool IsGrounded()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distanceToGround + 0.2f);
	}

	public Vector2 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
	public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
	public float Accel { get => accel; set => accel = value; }
	public float JumpForce { get => jumpForce; set => jumpForce = value; }
	public float Deaccel { get => deaccel; set => deaccel = value; }
}
