using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : CollisionBehavior
{
	public EnemyCollision(Enemy enemy) :
		base(enemy)
	{
	}

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
