using System;
using System.Collections.Generic;
using UnityEngine;

class EnemyManager
{
	private static EnemyManager instance;
	private List<GameObject> activeEnemies;                      // contains the active and alive enemies
	private static readonly object mutex = new object();        // used for locking and mutual exclusion

	private EnemyManager()
	{
		activeEnemies = new List<GameObject>();
	}

	public static EnemyManager GetInstance()
	{
		lock (mutex)
		{
			if (instance == null)
				instance = new EnemyManager();
			return instance;
		}
	}

	public void AddEnemy(GameObject enemy)
	{
		lock (mutex)
		{
			activeEnemies.Add(enemy);
		}
	}

	public void RemoveEnemy(GameObject enemy)
	{
		lock (mutex)
		{
			activeEnemies.Remove(enemy);
		}
	}

	/*
		GetObjectsCloseTo

		Parameters: The position of reference, the magnitude distance that will be used for comparisons
		Purpose: Returns a list of all enemies that are within the distance provided of the position provided
		Returns: a list of GameObjects that fit the conditions, may be empty
	*/
	public List<GameObject> GetObjectsCloseTo(Vector2 position, int magnitudeDistance)
	{
		lock (mutex)
		{
			List<GameObject> result = new List<GameObject>();

			foreach (GameObject @object in activeEnemies)
			{
				// check the position of this object
				Vector2 objectPosition = @object.transform.position;
				Vector2 distance = objectPosition - position;

				// if it is within the range
				if (distance.magnitude <= magnitudeDistance)
				{
					result.Add(@object);
				}
			}
			return result;
		}
	}
}

