using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity
{
	public enum EnemyState { IDLE, PATROL, COMBAT, DEAD, ATTACKING };	// possible states of an enemy

	private int health;													// base health of this enemy
	[SerializeField] private List<EnemyBehavior> enemyComponents;		// All the components (other than AI) associated with this object
	[SerializeField] private AIBehavior intelComponent;					// AI comp - determines the state
	[SerializeField] private List<CollisionBehavior> collisionBehaviors;// behaviors that define how the object behaves with collisions
	[SerializeField] private GameObject player = null;                  // the player
	[SerializeField] private HealthBehavior healthBehavior;             // the player
	private EnemyState currentState = EnemyState.IDLE;					// Current state of this enemy
	private Vector3 movementWaypoint;									// This waypoint gets set by the AI component
	private bool waypointSet = false;									// indicates if we need to set a new waypoint
	private GameEntity targetedEntity = null;							// Entity that has been targeted for combat
	private bool attacking = false;										// indicates if this enemy is attacking

	public Enemy(
		List<EnemyBehavior> components,
		AIBehavior intel) : base()
	{
		enemyComponents = components;
		intelComponent = intel;
		collisionBehaviors = new List<CollisionBehavior>();
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
	public override void Update()
	{
		base.Update();
		// All of our components define the behavior for this specefic enemy
		// so, we just call the components, and they do what is needed

		// The specefic order is such that the AIcomponent can made a decision
		// on what to do, then each of the additional components can act based on that position.

		// The AI comp. has to act first and make a decision
		intelComponent.Act();

		foreach (EnemyBehavior component in enemyComponents)
		{
			component.Act();
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		// We execute every collision behavor belonging to this object
		foreach(CollisionBehavior behavior in collisionBehaviors)
		{
			behavior.SetCollision(collision);
			behavior.Act();
		}
	}

	public void OnDamage(float damageAmount)
	{
		// The single health behavior belonging to this object is executed
		healthBehavior.SetDamage(damageAmount);
		healthBehavior.Act();
	}

	public int Health { get => health; set => health = value; }
	public EnemyState State { get => currentState; set => currentState = value; }
	public GameEntity TargetedEntity { get => targetedEntity; set => targetedEntity = value; }
	public bool WaypointSet { get => waypointSet; set => waypointSet = value; }
	public Vector3 MovementWaypoint { get => movementWaypoint; set => movementWaypoint = value; }
	public GameObject Player { get => player; }
	public bool Attacking { get => attacking; set => attacking = value; }
}
