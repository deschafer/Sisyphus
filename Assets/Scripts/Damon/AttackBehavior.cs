using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	AttackBehavior
	
	Author: Damon Schafer
	Purpose: Provides a base class for all AttackBehaviors that can be added to 
	enemy objects.
*/
public abstract class AttackBehavior : EnemyBehavior
{
	/*
		AttackBehavior

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new AttackBehavior, initializes the super class
	*/
	public AttackBehavior(Enemy entity) :
		base(entity)
	{
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
		// if the entity is dead, then the entity cannot attack
		if (ParentEntity.State == Enemy.EnemyState.DEAD)
			return false;

		return true;
	}
}
