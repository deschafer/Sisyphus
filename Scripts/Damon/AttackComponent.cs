using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : EnemyComponent
{
	public AttackComponent(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	public override bool Act()
	{
		return false;
	}
}
