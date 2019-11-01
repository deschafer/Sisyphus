using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditIntelligence : AIBehavior
{
	private const int patrolRadius = 20;		// the max radius of where a movement waypoint can be set from the spawnposition
	private bool playerVisible = false;			// flag indicating if the player is visible and detected
	private Vector2 movementWaypointOrigin;     // The position of the parent entity when a waypoint was chosen
	private const int attackRadius = 20;

	public BanditIntelligence(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
    {
		parentEntity.State = Enemy.EnemyState.IDLE;
		parentEntity.Health = 100;
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
		if (IsPlayerVisible())
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
			parentEntity.WaypointSet = false;
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
			Debug.Log("Waypoint reached");
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

		// save the current position for checking if we reached the position
		movementWaypointOrigin = parentEntity.transform.position;	

		// Then, for now, just pick a point on one side of the position
		Vector3 waypoint = position + (Random.Range(0.0f, 1.0f) >= 0.5 ? new Vector3(-patrolRadius, 0, 0) : new Vector3(patrolRadius, 0, 0));

		string str = waypoint.x + " " + waypoint.y + " " + waypoint.z + " ";

		Debug.Log("Waypoint selected");
		Debug.Log(str);

		// Finally saving this information
		parentEntity.MovementWaypoint = waypoint;
		parentEntity.WaypointSet = true;
		parentEntity.State = Enemy.EnemyState.PATROL;
	}

	private void Combat()
	{
		// We set a new waypoint at the player's position,
		Vector2 playerPos = parentEntity.Player.transform.position;
		// and set this as the parentEntity's movement waypoint.
		parentEntity.MovementWaypoint = playerPos;
		parentEntity.WaypointSet = true;
	}

	//
	// IsWaypointReached()
	// Returns true if the parent entity has reached or passed the 
	// current selected movement waypoint
	//
	private bool IsWaypointReached()
	{
		// if we were on the left of the origin poisition, then we check if we are on the left of the waypoint
		if (parentEntity.transform.position.x < movementWaypointOrigin.x &&
			parentEntity.transform.position.x < parentEntity.MovementWaypoint.x)
		{
			return true;
		}

		// if we were on the right of the origin poisition, then we check if we are on the right of the waypoint
		if (parentEntity.transform.position.x > movementWaypointOrigin.x &&
			parentEntity.transform.position.x > parentEntity.MovementWaypoint.x)
		{
			return true;
		}

		return false;
	}

	private bool IsPlayerVisible()
	{
		if (!parentEntity.Player)
		{
			return false;
		}

		Vector2 playerPosition = parentEntity.Player.transform.position;
		Vector2 enemyPosition = parentEntity.transform.position;
		Vector2 difference = playerPosition - enemyPosition;

		if (difference.magnitude < attackRadius)
		{
			Debug.Log("Player is visible");
			playerVisible = true;
			return true;
		}

		playerVisible = false;

		return false;
	}
}
