using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	GameEntity
	
	Author: Damon Schafer
	Purpose: Provides a base class that contains basic movement behavior
*/
public abstract class GameEntity : MonoBehaviour
{
	new private Rigidbody2D rigidbody2D;		// the rigidbody2d component belonging to this gameobject
	private Animator animator;                  // the animator componenet belonging to this gameobject
	private new Collider2D collider2D;          // the collider2d component belonging to this gameobject
	private new SpriteRenderer renderer;        // the renderer component belonging to this gameobject
	private Vector2 spawnPosition;				// the original position where this entity was spawned
	private float maxSpeed = 100;				// a max speed for the velocity	
	private float maxHorizontalSpeed = 50;		// a max horizontal speed
	private float jumpForce = 6;                // the jump force of this object, indicates strength of jumps

	/*
		GameEntity

		Purpose: Creates a new GameEntity and sets some initial values
	*/
	public GameEntity()
	{
		// Set default values
		maxSpeed = 10;
		jumpForce = 6;
	}

	/*
		Start

		Purpose: Called by Unity before the first frame, it serves to create data structures and 
			and initialize some data
	*/
	public void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		collider2D = GetComponent<Collider2D>();
		renderer = GetComponent<SpriteRenderer>();
		spawnPosition = transform.position;
	}

	/*
		Update

		Purpose: Called by Unity continuously to update this object. This is kept
			virtual and empty so it can be derived by derived classes.
	*/
	public virtual void Update()
	{
	}

	/*
		MoveLeft

		Purpose: Sets the velocity of this object to the max horiz speed
			in the left direction
	*/
	public void MoveLeft()
	{
		Rigidbody2D.velocity = new Vector2(-maxHorizontalSpeed, Rigidbody2D.velocity.y);
	}

	/*
		MoveRight

		Purpose: Sets the velocity of this object to the max horiz speed
			in the right direction
	*/
	public void MoveRight()
	{
		Rigidbody2D.velocity = new Vector2(maxHorizontalSpeed, Rigidbody2D.velocity.y);
	}

	/*
		Jump

		Purpose: If the current object is grounded, then a jump force is added to the object
			to simulate a jump action
	*/
	public void Jump()
	{
		if (IsGrounded() && Rigidbody2D.velocity.y == 0.0f)
		{
			Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	/*
		ShiftUp

		Purpose: Used to shift the object up one pixel to get the object unstuck if it was
			previously stuck.
	*/
	public void ShiftUp()
	{
		transform.Translate(0, 1, 0);
	}

	/*
		ShiftUp

		returns: true if the object is grounded, false if the object is not
		Purpose: Used to check if the object is grounded
	*/
	public bool IsGrounded()
	{
		// Checking below this object to see if we have hit the ground
		return Physics2D.Raycast(transform.position, -Vector3.up, 0.01f) || 
			Physics2D.Raycast(new Vector3(transform.position.x + Renderer.size.x, transform.position.y, transform.position.z), -Vector3.up, 0.01f);
	}

	/*
		Getters and Setters

		Parameters:	takes a value of the approp. type to set the variable
		Returns: the object of the given type
		Purpose: used to set/get the given variable
	*/
	public Vector2 SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
	public float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
	public float JumpForce { get => jumpForce; set => jumpForce = value; }
	public float MaxHorizontalSpeed { get => maxHorizontalSpeed; set => maxHorizontalSpeed = value; }
	public Animator Animator { get => animator; }
	public SpriteRenderer Renderer { get => renderer; }
	public Collider2D Collider2D { get => collider2D; }
	public Rigidbody2D Rigidbody2D { get => rigidbody2D; }
}
