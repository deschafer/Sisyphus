using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	MovementBehavior
	
	Author: Damon Schafer
	Purpose: This class provides a base class for all MovementBehaviors
*/
public class MovementBehavior : EnemyBehavior
{
	/*
		MovementBehavior

		Parameters: Takes an enemy reference of the object that owns this behavior
		Purpose: Creates a new MovementBehavior and calls the super class' constructor
	*/
	public MovementBehavior(Enemy entity) :
		  base(entity)
	{
	}

	/*
		Act

		Returns: True if any following derived classes should be executed, and false if they should return
		Purpose: Executes this behavior
	*/
	public override bool Act()
	{
		// Needs to check if the enemy is in a moving state
		// If it is not, then we do not move
		if (ParentEntity.State == Enemy.EnemyState.IDLE ||
			ParentEntity.State == Enemy.EnemyState.DEAD)
		{
			Debug.Log("Enemy not in valid move state");
			// We have to return, the AIComp will change the states
			return false;
		}
		// If a waypoint is not set, then we do not move.
		if (!ParentEntity.WaypointSet)
		{
			Debug.Log("Enemy waypoint not set");
			return false;
		}

		return true;
	}
}
