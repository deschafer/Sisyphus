using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	BanditIntelligence
	
	Author: Damon Schafer
	Purpose: The AIBehavior derived class added to the bandit to give it intelligent behavior
*/
public class BanditIntelligence : AIBehavior
{
	protected int patrolRadius = 20;      // the max radius of where a movement waypoint can be set from the spawnposition
	protected bool playerVisible = false;           // flag indicating if the player is visible and detected
	protected Vector2 movementWaypointOrigin;     // The position of the parent entity when a waypoint was chosen
	protected const int attackRadius = 20;

	/*
		BanditIntelligence

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new BanditIntelligence, initializes the super class
	*/
	public BanditIntelligence(Enemy entity) :
		base(entity)
	{
	}

	/*
		Start

		Purpose: initializes our timer before this object is used
	*/
	void Start()
    {
		ParentEntity.State = Enemy.EnemyState.IDLE;
		ParentEntity.Health = 100;
    }

	/*
		Act

		Returns: true: Any additional derived Act methods can be executed. False: the
			derived act methods should not be executed.
		Purpose: This is the main method where this behavior modifies its parent. This should
			be overridden for each base class, and the value of the super Act() methods needs to be 
			true for the derived class to execute. This changes the state of the enemy based on its surroundings
	*/
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
			ParentEntity.State = Enemy.EnemyState.COMBAT;
			Combat();
			// We return here so we do not complete any additional actions
			// return false, because we do not want to complete any additional actions
			return false;
		}

		// If we have lost sight of the player
		if(ParentEntity.State == Enemy.EnemyState.COMBAT &&
			!playerVisible)
		{
			// then we want to go back to an idle state
			ParentEntity.State = Enemy.EnemyState.IDLE;
			// set our waypoint as false so we will get a new waypoint next cycle
			ParentEntity.WaypointSet = false;
			return false;
		}

		// So, we need to determine if we need to find a waypoint
		// If a waypoint has not yet been set
		if (!ParentEntity.WaypointSet)
		{
			// Then we need to determine where to place a waypoint
			PlaceWaypoint();
			return false;
		}

		// If we have reached a waypoint, set it as false
		if(IsWaypointReached())
		{
			Debug.Log("Waypoint reached");
			ParentEntity.WaypointSet = false;
			ParentEntity.State = Enemy.EnemyState.IDLE;
			return false;
		}

		return true;
	}

	/*
		PlaceWaypoint

		Purpose: Places a new waypoint a certain distance from this enemy's spawn location
	*/
	protected virtual void PlaceWaypoint()
	{
		// We place a movement waypoint based off the spawn position
		// so get the spawn position

		Vector3 position = ParentEntity.SpawnPosition;

		// save the current position for checking if we reached the position
		movementWaypointOrigin = ParentEntity.transform.position;	

		// Then, for now, just pick a point on one side of the position
		Vector3 waypoint = position + (Random.Range(0.0f, 1.0f) >= 0.5 ? new Vector3(-patrolRadius, 0, 0) : new Vector3(patrolRadius, 0, 0));

		string str = waypoint.x + " " + waypoint.y + " " + waypoint.z + " ";

		Debug.Log("Waypoint selected");
		Debug.Log(str);

		// Finally saving this information
		ParentEntity.MovementWaypoint = waypoint;
		ParentEntity.WaypointSet = true;
		ParentEntity.State = Enemy.EnemyState.PATROL;
	}

	/*
		Combat

		Purpose: Places a new waypoint at the player's position
	*/
	protected virtual void Combat()
	{
		// We set a new waypoint at the player's position,
		Vector2 playerPos = ParentEntity.Player.transform.position;

		// and set this as the parentEntity's movement waypoint.
		ParentEntity.MovementWaypoint = playerPos;
		ParentEntity.WaypointSet = true;
	}

	/*
		IsWaypointReached

		Returns: true if the waypoint has been reached, false otherwise
		Purpose: Used to determine if an enemy has reached its set waypoint
	*/
	protected virtual bool IsWaypointReached()
	{
		// if we were on the left of the origin poisition, then we check if we are on the left of the waypoint
		if (ParentEntity.transform.position.x < movementWaypointOrigin.x &&
			ParentEntity.transform.position.x < ParentEntity.MovementWaypoint.x)
		{
			return true;
		}

		// if we were on the right of the origin poisition, then we check if we are on the right of the waypoint
		if (ParentEntity.transform.position.x > movementWaypointOrigin.x &&
			ParentEntity.transform.position.x > ParentEntity.MovementWaypoint.x)
		{
			return true;
		}

		return false;
	}

	/*
		IsPlayerVisible

		Returns: true if the waypoint has been reached, false otherwise
		Purpose: Used to determine if an enemy has reached its set waypoint
	*/
	protected virtual bool IsPlayerVisible()
	{
		// If there is no player
		if (!ParentEntity.Player)
		{
			return false;
		}

		// Get positions of the player and the enemy, and the difference between
		Vector2 playerPosition = ParentEntity.Player.transform.position;
		Vector2 enemyPosition = ParentEntity.transform.position;
		Vector2 difference = playerPosition - enemyPosition;

		// If the player is close enough
		if (difference.magnitude < attackRadius)
		{
			playerVisible = true;
			return true;
		}

		// Otherwise it is not visible
		playerVisible = false;

		return false;
	}
}
