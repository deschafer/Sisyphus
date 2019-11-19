using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	BanditMovement
	
	Author: Damon Schafer
	Purpose: The MovementBehavior class added to the Bandit enemy to provide movement
*/
public class BanditMovement : MovementBehavior
{
	private Vector2 lastPosition = new Vector2();
	private int stuckCount = 0;

	/*
		BanditMovement

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new BanditAttack, initializes the super class
	*/
	public BanditMovement(Enemy entity) :
		base(entity)
	{
	}

	/*
		Start

		Purpose: called before the first frame update, used to initialize this object
	*/
	void Start()
	{
		ParentEntity.JumpForce = 16;
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

		// If we have made it here, then a waypoint has been set,
		// and this enemy is in a patrol state. We can then focus on 
		// moving to our set waypoint

		// If the player is stuck
		if (lastPosition.x == ParentEntity.Rigidbody2D.position.x &&
			lastPosition.y == ParentEntity.Rigidbody2D.position.y)
		{
			// increment a count of this
			stuckCount++;

			// If stuck for more than 5 frames, shift it up to break free
			if (stuckCount > 5)
				ParentEntity.ShiftUp();
		}
		// reset this counter
		else
			stuckCount = 0;

		// get the last position for comparisons if we are not stuck
		// used to compared with the next frame
		if (stuckCount == 0)
			lastPosition = ParentEntity.Rigidbody2D.position;

		// Since we do not know anything meaningful about the map right now, we always jump
		ParentEntity.Jump();

		// We need to determine which direction to move in.
		Vector2 currentPosition = ParentEntity.transform.position;
		Vector2 waypoint = ParentEntity.MovementWaypoint;

		// We move to the right
		if (waypoint.x > currentPosition.x)
		{
			ParentEntity.MoveRight();
		}
		// we move to the left
		else
		{
			ParentEntity.MoveLeft();
		}

		return true;
	}
}
