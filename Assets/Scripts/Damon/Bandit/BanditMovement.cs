using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MovementBehavior
{
	private Vector2 lastPosition = new Vector2();
	private int stuckCount = 0;

	public BanditMovement(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
		ParentEntity.JumpForce = 16;
		ParentEntity.MaxSpeed = 20;
		ParentEntity.MaxHorizontalSpeed = 10;
	}

	// Update is called once per frame
	public override bool Act()
	{
		if (!base.Act())
		{
			return false;
		}

		// If we have made it here, then a waypoint has been set,
		// and this enemy is in a patrol state. We can then focus on 
		// moving to our set waypoint

		if (lastPosition.x == ParentEntity.Rigidbody2D.position.x &&
			lastPosition.y == ParentEntity.Rigidbody2D.position.y)
		{
			stuckCount++;
			if(stuckCount > 5)
				ParentEntity.ShiftUp();
		}
		else stuckCount = 0;

		if(stuckCount == 0)
			lastPosition = ParentEntity.Rigidbody2D.position;

		// for now, we always jump
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
