using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : EnemyBehavior
{
	public AttackBehavior(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	public override bool Act()
	{
		if (parentEntity.State == Enemy.EnemyState.DEAD)
		{
			return false;
		}

		return true;
	}
}
