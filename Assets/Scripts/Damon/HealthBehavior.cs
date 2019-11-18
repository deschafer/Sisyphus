using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	HealthBehavior
	
	Author: Damon Schafer
	Purpose: This is a class that provides basic health behavior to an object, the amount of
		damage taken can be specified.
*/
public class HealthBehavior : EnemyBehavior
{
	private float damage = 0;							// The damage taken by the enemy
	[SerializeField] private float damageRatio = 1.0f;  // the ratio by which this damage will be multiplied by

	/*
		HealthBehavior

		Parameters: Takes an enemy reference of the object that owns this behavior
		Purpose: Creates a new HealthBehavior and calls the super class' constructor
	*/
	public HealthBehavior(Enemy enemy) : 
		base(enemy)
	{
	}

	/*
		SetDamage

		Parameters: Takes a float that is the amount of damage taken
		Purpose: Sets the damage that was last taken for the next execution of this object
	*/
	public void SetDamage(float damage)
	{
		this.damage = damage;
	}

	/*
		Act

		Returns: True if any following derived classes should be executed, and false if they should return
		Purpose: Executes this behavior, translates damage taken to actual health lost
	*/
	public override bool Act()
	{
		// A dead entity cannot take any additional damage
		if(ParentEntity.State == Enemy.EnemyState.DEAD)
		{
			return false;
		}

		// removed the health of the parent entity
		ParentEntity.Health -= (int)Mathf.Round(damageRatio * damage);

		return true;
	}
}
