using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleIntelligence : BanditIntelligence
{

	private float altitude = 3.0f;
	private bool sweepingWaypointSet = false;
	private float noticePlayerTime = 10.0f;
	private float noticePlayerTimer = 0.0f;

	/*
		EagleIntelligence

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new EagleIntelligence, initializes the super class
	*/
	public EagleIntelligence(Enemy entity) :
		base(entity)
	{
	}

	/*
		Start

		Purpose: initializes data prior to this object's usage
	*/
	void Start()
	{
		ParentEntity.State = Enemy.EnemyState.IDLE;
		ParentEntity.Health = 80;
		altitude = 10.0f;

		noticePlayerTime = 10.0f;
		noticePlayerTimer = noticePlayerTime;
		patrolRadius = 30;
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
		// add to our timer each instance
		noticePlayerTimer += Time.deltaTime;

		// This is where this component will determine exactly what its parent
		// object does.

		// if we are attacking the player
		if(ParentEntity.State == Enemy.EnemyState.ATTACKING)
		{
			// then we set the waypoint as the 
			if(!sweepingWaypointSet)
			{
				SetWaypointOnPlayer();

				// our sweeping waypoint has been set
				sweepingWaypointSet = true;
			}
			else
			{
				// track the players movement
				SetWaypointOnPlayer();

				// if the eagle has hit its waypoint
				if (IsWaypointReached())
				{
					// we need to set a new waypoint directly up
					Vector2 newWaypoint = ParentEntity.transform.position;
					newWaypoint.y = altitude;

					// and set this as the parentEntity's movement waypoint.
					ParentEntity.MovementWaypoint = newWaypoint;
					ParentEntity.WaypointSet = true;

					// also change the state
					ParentEntity.State = Enemy.EnemyState.PATROL;

					// and set the sweeping waypoint as false
					sweepingWaypointSet = false;

					// then we need to set a timer until the player is visible again
					noticePlayerTimer = 0.0f;

					// set the player as not visible anymore
					playerVisible = false;
				}
			}

			return false;
		}

		// First, we check if a player is visible
		if (IsPlayerVisible())
		{
			// First we enter an attack state to mark this 
			ParentEntity.State = Enemy.EnemyState.COMBAT;
			Combat();

			// now we check if we have reached our new waypoint, 
			// this would mean we are directly above the enemy
			if (IsWaypointReached())
			{
				Debug.Log("Enemy is above player");

				// now we swoop down on the player
				ParentEntity.State = Enemy.EnemyState.ATTACKING;

			}

			// We return here so we do not complete any additional actions
			// return false, because we do not want to complete any additional actions
			return false;
		}

		// If we have lost sight of the player
		if (ParentEntity.State == Enemy.EnemyState.COMBAT &&
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
		if (IsWaypointReached())
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
	protected override void PlaceWaypoint()
	{
		base.PlaceWaypoint();
		Vector2 vector = ParentEntity.MovementWaypoint;
		vector.y = altitude;
		ParentEntity.MovementWaypoint = vector;
	}

	/*
		Combat

		Purpose: Places a new waypoint at the player's position
	*/
	protected override void Combat()
	{
		// We set a new waypoint at the player's position,
		Vector2 playerPos = ParentEntity.Player.transform.position;
		playerPos.y = altitude;

		// and set this as the parentEntity's movement waypoint.
		ParentEntity.MovementWaypoint = playerPos;
		ParentEntity.WaypointSet = true;
	}

	/*
		IsWaypointReached

		Returns: true if the waypoint has been reached, false otherwise
		Purpose: Used to determine if an enemy has reached its set waypoint
	*/
	protected override bool IsWaypointReached()
	{
		// check if we are close enough to the actual waypoint
		Vector2 distance = ParentEntity.MovementWaypoint - ParentEntity.transform.position;

		// if this distance is sufficiently small enough
		if (distance.magnitude <= 0.5f)
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
	protected override bool IsPlayerVisible()
	{
		if (noticePlayerTimer >= noticePlayerTime)
		{
			return base.IsPlayerVisible();
		}
		else return false;
	}

	private void SetWaypointOnPlayer()
	{
		// set the waypoint as the players position
		Vector2 playerPos = ParentEntity.Player.transform.position;

		// set this at the top of the player, so add its height
		playerPos.y += ParentEntity.Player.GetComponent<BoxCollider2D>().bounds.size.y - 1.0f;

		// and set this as the parentEntity's movement waypoint.
		ParentEntity.MovementWaypoint = playerPos;
		ParentEntity.WaypointSet = true;
	}
}
