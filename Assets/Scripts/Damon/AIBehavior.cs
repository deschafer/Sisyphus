using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	AIBehavior
	
	Author: Damon Schafer
	Purpose: The base class used for all AIBehaviors which will be added to enemies
		to given them intelligent behavior.
*/
public abstract class AIBehavior : EnemyBehavior
{
	/*
		AIBehavior

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new AIBehavior, initializes the super class
	*/
	public AIBehavior(Enemy entity) :
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
		// if the entity is dead, then the AI does not need to act
		if (ParentEntity.Health <= 0)
		{
			ParentEntity.State = Enemy.EnemyState.DEAD;
			return false;
		}

		// The AI will act
		return true;
	}
}
