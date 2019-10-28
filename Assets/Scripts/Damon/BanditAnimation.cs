using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimation : EnemyBehavior
{
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

		if (!parentEntity.IsGrounded())
		{
			parentEntity.Animator.SetTrigger("Jump");
			return false;
		}
		else
		{
			parentEntity.Animator.SetBool("Grounded", true);
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
