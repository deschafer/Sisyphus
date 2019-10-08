using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity
{
	public enum EnemyState { IDLE, PATROL, COMBAT, DEAD };

	new private string name;								// name/id of this enemy
	private int health;                                 // base health of this enemy
	public List<EnemyComponent> enemyComponents;		// All the components (other than AI) associated with this object
	public AIComponent intelComponent;					// AI comp - determines the state
	private EnemyState currentState = EnemyState.IDLE;  // Current state of this enemy
	private Vector3 movementWaypoint;					// This waypoint gets set by the AI component
	private bool waypointSet = false;
	private GameEntity targetedEntity = null;			// Entity that has been targeted for combat


	public Enemy(
		string name, 
		List<EnemyComponent> components,
		AIComponent intel)
	{
		this.name = name;
		enemyComponents = components;
		intelComponent = intel;
	}

	//
	// Start()
	// Start is called before the first frame update
	//
	new public void Start()
	{
		base.Start();
	}

	//
	// Update()
	// Update is called once per frame
	//
	new public void Update()
	{
		base.Update();
		// All of our components define the behavior for this specefic enemy
		// so, we just call the components, and they do what is needed

		// The specefic order is such that the AIcomponent can made a decision
		// on what to do, then each of the additional components can act based on that position.

		// The AI comp. has to act first and make a decision
		intelComponent.Act();

		// Then all of our components react accordingly
		animator.SetInteger("AnimState", 0);

		foreach (EnemyComponent component in enemyComponents)
		{
			component.Act();
		}
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

	public GameEntity TargetedEntity { get => targetedEntity; set => targetedEntity = value; }
	public bool WaypointSet { get => waypointSet; set => waypointSet = value; }
	public Vector3 MovementWaypoint { get => movementWaypoint; set => movementWaypoint = value; }
}
