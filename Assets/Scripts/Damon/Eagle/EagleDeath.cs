using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	EagleDeath
	
	Author: Damon Schafer
	Purpose: Provides a class to put the Eagle in a death state, and eventually 
		destroy this object
*/
public class EagleDeath : EnemyBehavior
{
	private float timer = 0;            // timer used to keep track of how much time
	private float despawnTime = 2;      // the amount of time needed to pass to destroy/despawn this object's parentEntity

	/*
		EnemyDeath

		Parameters: The Enemy that this behavior is attached
		Purpose: creates a new EnemyDeath
	*/
	public EagleDeath(Enemy enemy) :
		base(enemy)
	{
	}

	/*
		Start

		Purpose: called on object initialization, inits this object
	*/
	private void Start()
	{
		timer = 0;
		despawnTime = 2;
	}

	/*
		Act

		Parameters: The Enemy that this behavior is attached
		Returns: Returns true if the derived methods should continue, and false if they should not
		Purpose: Executes this behavior; determines if the enemy is dead, and sets the death state,
			and after a set time, destroys this object
	*/
	public override bool Act()
	{
		if (ParentEntity.State == Enemy.EnemyState.DEAD)
		{
			return false;
		}

		// if the enemy's health is too low
		if (ParentEntity.Health <= 0)
		{
			ParentEntity.State = Enemy.EnemyState.DEAD;

			// since this is an eagle, we need it to drop out of the sky
			// so set the gravity scale of the parent's rigidbody
			ParentEntity.Rigidbody2D.gravityScale = 1.0f;

			// then we should set the eagle in the eagle death animation
			ParentEntity.Animator.SetBool("dead", true);

			// then flip over the eagle
			ParentEntity.transform.localScale = new Vector3(-10, -10);

			ParentEntity.Rigidbody2D.velocity = new Vector2(0, 0);
		}

		// If the entity is not dead, then we do not need to go any further
		if (ParentEntity.State != Enemy.EnemyState.DEAD)
		{
			return false;
		}

		// In a fixed amount of time, we destroy the object
		timer += Time.deltaTime;
		if (timer >= despawnTime)
		{
			// remove the object from the list
			EnemyManager.GetInstance().RemoveEnemy(ParentEntity.gameObject);

			// then we despawn the object
			Destroy(ParentEntity.gameObject);

			// reset our timer
			timer = 0;
		}
		return true;
	}
}
