using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimation : EnemyBehavior
{
	private bool jumped = false;
	private bool dead = false;

	public BanditAnimation(Enemy entity) : 
		base(entity)
	{
	}


	public override bool Act()
	{

		// Swap direction of sprite depending on walk direction
		if (ParentEntity.Rigidbody2D.velocity.x < 0)
			transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
		else if (ParentEntity.Rigidbody2D.velocity.x > 0)
			transform.localScale = new Vector3(-10.0f, 10.0f, 10.0f);

		if (dead) return false;

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
