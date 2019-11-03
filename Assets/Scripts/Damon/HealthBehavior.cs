using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : EnemyBehavior
{
	private float damage = 0;							// The damage taken by the enemy
	[SerializeField] private float damageRatio = 1.0f;	// the ratio by which this damage will be multiplied by

	public HealthBehavior(Enemy enemy) : 
		base(enemy)
	{
	}

	public void SetDamage(float damage)
	{
		this.damage = damage;
	}

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
