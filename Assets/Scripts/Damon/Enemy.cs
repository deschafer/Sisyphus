using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity
{
	public enum EnemyState { IDLE, PATROL, COMBAT, DEAD };

	private string name;								// name/id of this enemy
	private int health;									// base health of this enemy
	private EnemyComponent defenseComponent;			// this comp adds defense and damage
	private EnemyComponent attackComponent;				// this comp adds attack behavior
	private EnemyComponent movementComponent;			// this comp determines the movement
	private AIComponent intelComponent;					// AI comp - determines the state
	private EnemyState currentState = EnemyState.IDLE;	// Current state of this enemy

	private GameEntity targetedEntity = null;			// Entity that has been targeted for combat

	public Enemy(
		string name, 
		EnemyComponent defense,
		EnemyComponent attack,
		EnemyComponent movement,
		AIComponent intel)
	{
		this.name = name;
		defenseComponent = defense;
		attackComponent = attack;
		movementComponent = movement;
		intelComponent = intel;
	}

	//
	// Start()
	// Start is called before the first frame update
	//
	void Start()
	{
	}

	//
	// Update()
	// Update is called once per frame
	//
	void Update()
	{
		// All of our components define the behavior for this specefic enemy
		// so, we just call the components, and they do what is needed

		// The specefic order is such that the AIcomponent can made a decision
		// on what to do, then each of the additional components can act based on that position.

		intelComponent.Act();
		defenseComponent.Act();
		movementComponent.Act();
		attackComponent.Act();
	}

	//
	// getHealth()/setHealth()
	// Used to access and modify the current health of this enemy
	//
	public int Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
		}
	}

	//
	// getHealth()/setHealth()
	// Used by components to set the state of this object
	//
	public EnemyState State
	{
		get
		{
			return currentState;
		}
		set
		{
			currentState = value;
		}
	}
}
