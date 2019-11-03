using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	CollisionBehavior
	
	Author: Damon Schafer
	Purpose: Provides a base class for all CollisionBehavior objects that can be added
	to Enemy classes.
*/
public abstract class CollisionBehavior : EnemyBehavior
{
	protected Collision2D collision;    // The last referenced collision

	/*
		CollisionBehavior

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new CollisionBehavior, initializes the super class
	*/
	public CollisionBehavior(Enemy entity) :
		 base(entity)
	{
	}

	/*
		SetCollision

		Parameters: The collision to be added to this object
		Purpose: Sets the collision that will be used in the next Act()
	*/
	public void SetCollision(Collision2D collision)
	{
		this.collision = collision;
	}

	/*
		Act

		Returns: true: Any additional derived Act methods can be executed. False: the
			derived act methods should not be executed.
		Purpose: This is the main method where this behavior modifies its parent. This should
			be overridden for each base class, and the value of the super Act() methods needs to be 
			true for the derived class to execute.
	*/
	public override bool Act()
	{
		// If the enemy is dead, then we do not handle collisions
		if(ParentEntity.State == Enemy.EnemyState.DEAD)
			return false;

		return true;
	}
}
