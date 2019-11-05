using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : EnemyBehavior
{
	private float timer = 0;
	private float despawnTime = 2;

    public EnemyDeath(Enemy enemy) :
		base(enemy)
	{
	}

	private void Start()
	{
		timer = 0;
		despawnTime = 2;
	}

	public override bool Act()
	{
		// just to test the death for now
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ParentEntity.State = Enemy.EnemyState.DEAD;
		}

		// If the entity is not dead, then we do not need to go any further
		if (ParentEntity.State != Enemy.EnemyState.DEAD)
		{
			return false;
		}

		// In a fixed amount of time, we destroy the object
		timer += Time.deltaTime;
		if (timer >= despawnTime)
		{
			// remove the object from the list
			EnemyManager.GetInstance().RemoveEnemy(ParentEntity.gameObject);

			// then we despawn the object
			Destroy(ParentEntity.gameObject);

			// reset our timer
			timer = 0;
		}
		return true;
	}
}
