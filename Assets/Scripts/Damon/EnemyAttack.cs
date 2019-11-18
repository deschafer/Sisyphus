using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	BanditAttack
	
	Author: Damon Schafer
	Purpose: The class added to the Enemy to provide attack behavior
*/
public class EnemyAttack : AttackBehavior
{
	private float timer = 0;                    // the float timer used to keep track of time passed
	[SerializeField] private float attackTime = 1;         // the time needed between attacks
	[SerializeField] private float attackDistance = 4.5f;  // the distance that this object must be within to attack
	[SerializeField] private float damage = 10.0f;

	/*
		BanditAttack

		Parameters: The parent entity (Enemy) for which this behavior belongs to 
		Purpose: creates a new BanditAttack, initializes the super class
	*/
	public EnemyAttack(Enemy enemy) :
		base(enemy)
	{
	}

	/*
		Start

		Purpose: initializes our timer before this object is used
	*/
	public void Start()
	{
		timer = 0;
		damage = 10.0f;
	}

	/*
		Act

		Returns: true: Any additional derived Act methods can be executed. False: the
			derived act methods should not be executed.
		Purpose: This is the main method where this behavior modifies its parent. This should
			be overridden for each base class, and the value of the super Act() methods needs to be 
			true for the derived class to execute. This keeps track of the timer, and if the player is
			close enough, attacks the player
	*/
	public override bool Act()
	{
		if (!base.Act())
		{
			return false;
		}

		// add the elapsed time from the last frame
		timer += Time.deltaTime;

		// if we are not attacking
		if (!ParentEntity.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
		{
			ParentEntity.Attacking = false;
		}

		// get the player position
		Vector2 playerPosition = ParentEntity.Player.transform.position;
		Vector2 enemyPosition = ParentEntity.transform.position;
		Vector2 distance = playerPosition - enemyPosition;

		// determine if we are close enough to the player to attack
		if (distance.magnitude <= attackDistance)
		{
			// then we can attack
			Attack();
		}

		return true;
	}

	/*
		Attack

		Purpose: If enough time has passed, this method resets our timer, sets the
			current animation as the attack animation, and attacks the player
	*/
	private void Attack()
	{
		// if enough time has passed since the last attack
		if (timer >= attackTime)
		{
			// set the attack animation
			ParentEntity.Animator.SetTrigger("Attack");

			// reset our timer
			timer = 0;

			// damage the player
			Debug.Log("Attacked player");

			ParentEntity.Attacking = true;

			// TODO: add the method that actually damages the player
			ParentEntity.Player.GetComponent<PlayerHealth>().health -= damage;
		}
	}
}
