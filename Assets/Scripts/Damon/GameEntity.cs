using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEntity : MonoBehaviour
{
	new private Rigidbody2D rigidbody2D;		// the rigidbody2d component belonging to this gameobject
	private Animator animator;                  // the animator componenet belonging to this gameobject
	private new Collider2D collider2D;          // the collider2d component belonging to this gameobject
	private new SpriteRenderer renderer;        // the renderer component belonging to this gameobject
	private Vector2 spawnPosition;				// the original position where this entity was spawned
	private float maxSpeed = 100;				// a max speed for the velocity	
	private float maxHorizontalSpeed = 50;		// a max horizontal speed
	private float jumpForce = 6;				// the jump force of this object, indicates strength of jumps

	public GameEntity()
	{
		// Set default values
		maxSpeed = 10;
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

	public virtual void Update()
	{
	}

	public void MoveLeft()
	{
		Rigidbody2D.velocity = new Vector2(-maxHorizontalSpeed, Rigidbody2D.velocity.y);
	}

	public void MoveRight()
	{
		Rigidbody2D.velocity = new Vector2(maxHorizontalSpeed, Rigidbody2D.velocity.y);
	}

	public void Jump()
	{
		if (IsGrounded() && Rigidbody2D.velocity.y == 0.0f)
		{
			Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	public void ShiftUp()
	{
		transform.Translate(0, 1, 0);
	}

	public bool IsGrounded()
	{
		// Checking below this object to see if we have hit the ground
		return Physics2D.Raycast(transform.position, -Vector3.up, 0.01f) || 
			Physics2D.Raycast(new Vector3(transform.position.x + Renderer.size.x, transform.position.y, transform.position.z), -Vector3.up, 0.01f);
	}

	public Vector2 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
	public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
	public float JumpForce { get => jumpForce; set => jumpForce = value; }
	public float MaxHorizontalSpeed { get => maxHorizontalSpeed; set => maxHorizontalSpeed = value; }
	public Animator Animator { get => animator; }
	public SpriteRenderer Renderer { get => renderer; }
	public Collider2D Collider2D { get => collider2D; }
	public Rigidbody2D Rigidbody2D { get => rigidbody2D; }
}
