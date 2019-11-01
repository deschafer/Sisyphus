using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimation : EnemyBehavior
{
	private bool jumped = false;

	public BanditAnimation(Enemy entity) : 
		base(entity)
	{
	}


	public override bool Act()
	{

		// Swap direction of sprite depending on walk direction
		if (parentEntity.rigidbody2D.velocity.x < 0)
			transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
		else if (parentEntity.rigidbody2D.velocity.x > 0)
			transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);

		// If we are not on the ground, and we have not already set our jump animation,
		// and we are not attacking
		if (!parentEntity.IsGrounded() && 
			!jumped && 
			!parentEntity.Attacking)
		{
			parentEntity.Animator.SetTrigger("Jump");
			parentEntity.Animator.SetBool("Grounded", false);
			jumped = true;
			return false;
		}
		// if we are attacking, we want this animation to play, so return
		else if(parentEntity.Attacking)
		{
			return false;
		}
		// if we are grounded, set it appropriately
		else if (parentEntity.IsGrounded())
		{
			jumped = false;
			parentEntity.Animator.SetBool("Grounded", true);
			return false;
		}
		// if we are jumping and in the air, we want to keep the jump animation
		else if(!parentEntity.IsGrounded())
		{
			return false;
		}

		switch (parentEntity.State)
		{
			case Enemy.EnemyState.ATTACKING:
				parentEntity.Animator.SetTrigger("Attack");
				break;
			case Enemy.EnemyState.COMBAT:
				break;
			case Enemy.EnemyState.DEAD:
				parentEntity.Animator.SetTrigger("Death");
				break;
			case Enemy.EnemyState.IDLE:
				parentEntity.Animator.SetInteger("AnimState", 0);
				break;
			case Enemy.EnemyState.PATROL:
				parentEntity.Animator.SetInteger("AnimState", 2);
				break;
			default:
				break;
		}

		return false;
	}
}
