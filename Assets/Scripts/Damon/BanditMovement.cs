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
		parentEntity.Accel = 100;
		parentEntity.JumpForce = 20;
		parentEntity.Deaccel = 5;
		parentEntity.MaxSpeed = 20;
		parentEntity.MaxHorizontalSpeed = 10;
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

		if (lastPosition.x == parentEntity.rigidbody2D.position.x &&
			lastPosition.y == parentEntity.rigidbody2D.position.y)
		{
			stuckCount++;
			if(stuckCount > 5)
				parentEntity.ShiftUp();
		}
		else stuckCount = 0;

		if(stuckCount == 0)
			lastPosition = parentEntity.rigidbody2D.position;

		// for now, we always jump
		parentEntity.Jump();

		// We need to determine which direction to move in.
		Vector2 currentPosition = parentEntity.transform.position;
		Vector2 waypoint = parentEntity.MovementWaypoint;

		// We move to the right
		if (waypoint.x > currentPosition.x)
		{
			parentEntity.MoveRight();
		}
		// we move to the left
		else
		{
			parentEntity.MoveLeft();
		}

		return true;
	}
}
