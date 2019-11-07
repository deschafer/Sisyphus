using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	EnemyCollision
	
	Author: Damon Schafer
	Purpose: Provides a class to handle collision for Enemies, ignores Enemies colliding
		with each other
*/
public class EnemyCollision : CollisionBehavior
{
	/*
		EnemyCollision

		Parameters: The Enemy that this behavior is attached
		Purpose: creates a new EnemyCollision
	*/
	public EnemyCollision(Enemy enemy) :
		base(enemy)
	{
	}

	/*
		EnemyCollision

		Parameters: The Enemy that this behavior is attached
		Returns: true/false, denotes if the derived class Act method should continue
		Purpose: executes the following behavior, handles collisions
	*/
	public override bool Act()
	{
		if (!base.Act())
			return false;

		// Enemies do not collide with other enemies
		if (collision.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision(collision.collider, ParentEntity.Collider2D);
		}

		return true;
	}
}
