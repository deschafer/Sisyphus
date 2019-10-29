using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : EnemyBehavior
{
	public AIBehavior(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	public override bool Act()
	{

		if (parentEntity.Health <= 0)
		{
			parentEntity.State = Enemy.EnemyState.DEAD;
			return false;
		}

		return true;
	}
}
