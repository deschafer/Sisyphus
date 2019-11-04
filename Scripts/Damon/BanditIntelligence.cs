using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditIntelligence : AIComponent
{
	private const int patrolRadius = 20;

	public BanditIntelligence(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
    {
		parentEntity.State = Enemy.EnemyState.PATROL;
    }

	// Update is called once per frame
	public override bool Act()
	{
		if (!base.Act())
		{
			return false;
		}

		// This is where this component will determine exactly what its parent
		// object does.

		// For now, we are just going to focus on handling simple movement waypoints.

		// So, we need to determine if we need to find a waypoint
		// If a waypoint has not yet been set
		if (!parentEntity.WaypointSet)
		{
			// Then we need to determine where to place a waypoint
			PlaceWaypoint();
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
	}
}
