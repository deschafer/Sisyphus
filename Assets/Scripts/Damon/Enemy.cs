using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameEntity
{
	public enum EnemyState { IDLE, PATROL, COMBAT, DEAD, ATTACKING };

	new private string name;								// name/id of this enemy
	private int health;										// base health of this enemy
	public List<EnemyBehavior> enemyComponents;				// All the components (other than AI) associated with this object
	public AIBehavior intelComponent;                       // AI comp - determines the state
	public GameObject player;								// the player
	private EnemyState currentState = EnemyState.IDLE;		// Current state of this enemy
	private Vector3 movementWaypoint;						// This waypoint gets set by the AI component
	private bool waypointSet = false;
	private GameEntity targetedEntity = null;				// Entity that has been targeted for combat
	private bool horizontalCollision = false;
	private bool verticalCollision = false;
	private bool attacking = false;


	public Enemy(
		string name, 
		List<EnemyBehavior> components,
		AIBehavior intel) : base()
	{
		this.name = name;
		enemyComponents = components;
		intelComponent = intel;
	}

	public Enemy()
	{
		
	}

	//
	// Start()
	// Start is called before the first frame update
	//
	public void Start()
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

		horizontalCollision = false;
		verticalCollision = false;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision(collision.collider, collider2D);
			return;
		}

		foreach (ContactPoint2D point in collision.contacts)
		{
			if (point.normal.y < 0 || point.normal.y > 0)
			{
				//rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
				verticalCollision = true;
			}
			else
			{
				rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
				horizontalCollision = true;
			}
		}
	}

	public int Health { get => health; set => health = value; }
	public EnemyState State { get => currentState; set => currentState = value; }
	public GameEntity TargetedEntity { get => targetedEntity; set => targetedEntity = value; }
	public bool WaypointSet { get => waypointSet; set => waypointSet = value; }
	public Vector3 MovementWaypoint { get => movementWaypoint; set => movementWaypoint = value; }
	public bool HorizontalCollision { get => horizontalCollision; set => horizontalCollision = value; }
	public bool VerticalCollision { get => verticalCollision; set => verticalCollision = value; }
	public GameObject Player { get => player; }
	public bool Attacking { get => attacking; set => attacking = value; }
}
