using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MovementBehavior
{

	/*
		BanditMovement

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new BanditAttack, initializes the super class
	*/
	public EagleMovement(Enemy entity) :
		base(entity)
	{
	}

	/*
		Start

		Purpose: called before the first frame update, used to initialize this object
	*/
	void Start()
	{
		ParentEntity.MaxSpeed = 20;
		ParentEntity.MaxHorizontalSpeed = 10;
	}

	/*
		Act

		Returns: true: Any additional derived Act methods can be executed. False: the
			derived act methods should not be executed.
		Purpose: This is the main method where this behavior modifies its parent. This should
			be overridden for each base class, and the value of the super Act() methods needs to be 
			true for the derived class to execute. This moves the player in the direction of the waypoint
	*/
	public override bool Act()
	{
		if (!base.Act())
		{
			return false;
		}

		// We need to determine which direction to move in.
		Vector2 currentPosition = ParentEntity.transform.position;
		Vector2 waypoint = ParentEntity.MovementWaypoint;

		// find the difference vector
		Vector2 difference = waypoint - currentPosition;

		// Swap direction of sprite depending on walk direction
		

		// if we are sufficiently far enough
		if (difference.magnitude > 0.5f)
		{
			// rotate the entity based on position
			if (ParentEntity.Rigidbody2D.velocity.x < 0)
				transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
			else if (ParentEntity.Rigidbody2D.velocity.x > 0)
				transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);

			ParentEntity.setVelocity(waypoint - currentPosition);
		}
		else
			ParentEntity.setVelocity(new Vector2(0, 0));

		return true;
	}
}