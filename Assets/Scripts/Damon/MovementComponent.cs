using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : EnemyComponent
{
	public MovementComponent(Enemy entity) :
		  base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	// Base form of this function
	// Will check if we can move at all in the first place
	public override bool Act()
	{
		// Needs to check if the enemy is in a moving state
		// If it is not, then we do not move
		if (parentEntity.State == Enemy.EnemyState.IDLE ||
			parentEntity.State == Enemy.EnemyState.DEAD)
		{
			Debug.Log("Enemy not in valid move state");
			return false;
		}
		// If a waypoint is not set, then we do not move.
		if (!parentEntity.WaypointSet)
		{
			Debug.Log("Enemy waypoint not set");
			return false;
		}

		return true;
	}
}
