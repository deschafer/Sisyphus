using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAttack : AttackBehavior
{
	private float timer = 0;
	private const float attackTime = 1;
	private const float attackDistance = 4.5f;

	public BanditAttack(Enemy enemy) : 
		base(enemy)
	{

	}

	// Start is called before the first frame update
	public void Start()
    {
		timer = 0;
    }

	// Update is called once per frame
	public void Update()
    {
        
    }

	public override bool Act()
	{
		if(!base.Act())
		{
			return false;
		}

		timer += Time.deltaTime;

		if(!parentEntity.Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
		{
			parentEntity.Attacking = false;
		}

		// get the player position
		Vector2 playerPosition = parentEntity.Player.transform.position;
		Vector2 enemyPosition = parentEntity.transform.position;
		Vector2 distance = playerPosition - enemyPosition;

		// determine if we are close enough to the player to attack
		if(distance.magnitude <= attackDistance)
		{
			// then we can attack
			Attack();
		}
	
		return true;
	}

	private void Attack()
	{
		// if enough time has passed since the last attack
		if(timer >= attackTime)
		{
			// set the attack animation
			parentEntity.Animator.SetTrigger("Attack");

			// reset our timer
			timer = 0;

			// damage the player
			Debug.Log("Attacked player");

			parentEntity.Attacking = true;
		}
	}
}
