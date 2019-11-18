using System;
using System.Collections.Generic;
using UnityEngine;

/*
	EnemyManager
	
	Author: Damon Schafer
	Purpose: Provides a class that contains references to all active enemies in the game
*/
class EnemyManager
{
	private static EnemyManager instance;
	private List<GameObject> activeEnemies;                      // contains the active and alive enemies
	private static readonly object mutex = new object();         // used for locking and mutual exclusion


	/*
		EnemyManager

		Purpose: Creates a new EnemyManager object, private to enforce singleton
	*/
	private EnemyManager()
	{
		activeEnemies = new List<GameObject>();
	}

	/*
		GetInstance

		Returns: the active instance of this singleton object
		Purpose: This gets the active instance, and if it has not already been set, creates
			a new EnemyFactory and sets the instance.
	*/
	public static EnemyManager GetInstance()
	{
		lock (mutex)
		{
			if (instance == null)
				instance = new EnemyManager();
			return instance;
		}
	}

	/*
		AddEnemy

		Parameters: The object to be added to the list of active enemies
		Purpose: Adds a new enemy to the list of active enemies
	*/
	public void AddEnemy(GameObject enemy)
	{
		lock (mutex)
		{
			activeEnemies.Add(enemy);
		}
	}

	/*
		AddEnemy

		Parameters: The object to be removed to the list of active enemies
		Purpose: Removes a new enemy to the list of active enemies
	*/
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

