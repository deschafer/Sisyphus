using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIComponent : EnemyComponent
{
	public AIComponent(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	public override bool Act()
	{

		// For right now, so we can test movement, just set the state as moving,
		// and set the waypoint as set

		parentEntity.WaypointSet = true;
		parentEntity.State = Enemy.EnemyState.PATROL;

		return false;
	}
}
