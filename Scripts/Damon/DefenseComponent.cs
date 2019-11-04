using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseComponent : EnemyComponent
{
	public DefenseComponent(Enemy entity) :
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
