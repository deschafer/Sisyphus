using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenegadeAnimation : EnemyBehavior
{

	public RenegadeAnimation(Enemy enemy) : 
		base(enemy)
	{
	}

	public override bool Act()
	{

		// if the player is moving
		if (ParentEntity.State == Enemy.EnemyState.PATROL)
		{
			// if the enemy has jumped and is in the air
			if (!ParentEntity.IsGrounded())
			{
				ParentEntity.Animator.SetBool("Jump", true);
				ParentEntity.Animator.SetBool("Run", false);
			}
			else
			{
				ParentEntity.Animator.SetBool("Run", true);
				ParentEntity.Animator.SetBool("Jump", false);
			}
		}
		// if the renegade is not moving
		else if (ParentEntity.State == Enemy.EnemyState.IDLE)
		{
			ParentEntity.Animator.SetBool("Run", false);
			ParentEntity.Animator.SetBool("Idle", true);
		}



		return true;
	}
}
