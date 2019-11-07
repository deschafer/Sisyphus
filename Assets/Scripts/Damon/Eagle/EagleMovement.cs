using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MovementBehavior
{
	private float height = 0;

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
		ParentEntity.MaxSpeed = 10;
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

		// we need to set y and x here

		// just standardize the difference vector by our max speed
		// add velocity to gameEntity
		ParentEntity.setVelocity(waypoint - currentPosition);


		

		return true;
	}
}