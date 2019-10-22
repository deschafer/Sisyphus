using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditIntelligence : AIBehavior
{
	private const int patrolRadius = 20;
	private bool playerVisible = false;

	public BanditIntelligence(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
    {
		parentEntity.State = Enemy.EnemyState.PATROL;
    }

	public override bool Act()
	{
		if (!base.Act())
		{
			return false;
		}

		// This is where this component will determine exactly what its parent
		// object does.

		// First, we check if a player is visible
		if (playerVisible)
		{
			// First we enter an attack state to mark this 
			parentEntity.State = Enemy.EnemyState.COMBAT;
			Combat();
			// We return here so we do not complete any additional actions
			// return false, because we do not want to complete any additional actions
			return false;
		}

		// If we have lost the player
		if(parentEntity.State == Enemy.EnemyState.COMBAT &&
			!playerVisible)
		{
			parentEntity.State = Enemy.EnemyState.IDLE;
			return false;
		}

		// So, we need to determine if we need to find a waypoint
		// If a waypoint has not yet been set
		if (!parentEntity.WaypointSet)
		{
			// Then we need to determine where to place a waypoint
			PlaceWaypoint();
			return false;
		}

		// If we have reached a waypoint, set it as false
		if(IsWaypointReached())
		{
			parentEntity.WaypointSet = false;
			parentEntity.State = Enemy.EnemyState.IDLE;
			return false;
		}

		return true;
	}

	private void PlaceWaypoint()
	{
		// We place a movement waypoint based off the spawn position
		// so get the spawn position

		Vector3 position = parentEntity.SpawnPosition;

		// Then, for now, just pick a point on one side of the position
		Vector3 waypoint = position + (Random.Range(0.0f, 1.0f) == 1.0 ? new Vector3(-patrolRadius, 0, 0) : new Vector3(patrolRadius, 0, 0));

		string str = waypoint.x + " " + waypoint.y + " " + waypoint.z + " ";

		Debug.Log(str);

		// Finally saving this information
		parentEntity.MovementWaypoint = waypoint;
		parentEntity.WaypointSet = true;
		parentEntity.State = Enemy.EnemyState.PATROL;
	}

	private void Combat()
	{

		// We need to set a chasing movement waypoint in the direction of the player


	}

	private bool IsWaypointReached()
	{

		// need to determine if the enemy has moved past the desired waypoint

		return false;
	}
}
