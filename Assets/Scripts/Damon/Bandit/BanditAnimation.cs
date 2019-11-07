using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	BanditAnimation
	
	Author: Damon Schafer
	Purpose: The class added to the Bandit enemy to provide animation behavior
*/
public class BanditAnimation : EnemyBehavior
{	
	private bool jumped = false;		// indicates we have jumped
	private bool dead = false;          // indicates we are dead

	/*
		BanditAnimation

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new BanditAnimation, initializes the super class
	*/
	public BanditAnimation(Enemy entity) : 
		base(entity)
	{
	}

	/*
		Act

		Returns: true: Any additional derived Act methods can be executed. False: the
			derived act methods should not be executed.
		Purpose: This is the main method where this behavior modifies its parent. This should
			be overridden for each base class, and the value of the super Act() methods needs to be 
			true for the derived class to execute. This sets the appropriate animation based on
			the current enemy state.
	*/
	public override bool Act()
	{

		// Swap direction of sprite depending on walk direction
		if (ParentEntity.Rigidbody2D.velocity.x < 0)
			transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
		else if (ParentEntity.Rigidbody2D.velocity.x > 0)
			transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);

		// if we are dead, do not change our animation as it has already been set
		if (dead) return false;

		// set the animation as dead
		if(ParentEntity.State == Enemy.EnemyState.DEAD)
		{
			ParentEntity.Animator.SetTrigger("Death");
			dead = true;
			return false;
		}
		// If we are not on the ground, and we have not already set our jump animation,
		// and we are not attacking
		else if (!ParentEntity.IsGrounded() && 
			!jumped && 
			!ParentEntity.Attacking)
		{
			ParentEntity.Animator.SetTrigger("Jump");
			ParentEntity.Animator.SetBool("Grounded", false);
			jumped = true;
			return false;
		}
		// if we are attacking, we want this animation to play, so return
		else if(ParentEntity.Attacking)
		{
			return false;
		}
		// if we are grounded, set it appropriately
		else if (ParentEntity.IsGrounded())
		{
			jumped = false;
			ParentEntity.Animator.SetBool("Grounded", true);
			return false;
		}
		// if we are jumping and in the air, we want to keep the jump animation
		else if(!ParentEntity.IsGrounded())
		{
			return false;
		}

		// Set the miscellaneous states
		switch (ParentEntity.State)
		{
			case Enemy.EnemyState.ATTACKING:
				ParentEntity.Animator.SetTrigger("Attack");
				break;
			case Enemy.EnemyState.COMBAT:
				break;
			case Enemy.EnemyState.DEAD:
				ParentEntity.Animator.SetTrigger("Death");
				break;
			case Enemy.EnemyState.IDLE:
				ParentEntity.Animator.SetInteger("AnimState", 0);
				break;
			case Enemy.EnemyState.PATROL:
				ParentEntity.Animator.SetInteger("AnimState", 2);
				break;
			default:
				break;
		}
		return false;
	}
}
