using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	EnemyFactory
	
	Author: Damon Schafer
	Purpose: This class follows Factory and Singleton design patterns. It stores registered GameObjects,
		and this class is the correct way to programitcally create new enemies in the game.
*/
public class EnemyFactory
{
	public static EnemyFactory instance;								// singleton instance reference
	private SortedDictionary<string, int> storedEnemyPrefabKeys;		// hash table used to store indicies in the list for enemyName's
	public List<GameObject> storedEnemyPrefabs;							// used to store the prefabs for the registered enemies
	private static readonly object mutex = new object();                // used for locking and mutual exclusion

	/*
		EnemyFactory

		Purpose: The default constructor of this object. It initializes the data structures, and 
			the object registers the prefabs.
	*/
	private EnemyFactory()
	{
		storedEnemyPrefabKeys = new SortedDictionary<string, int>();
		storedEnemyPrefabs = new List<GameObject>();

		// We register the enemies used
		RegisterEnemy("LightBandit", "LightBandit");
		RegisterEnemy("DarkBandit", "DarkBandit");
;	}

	/*
		GetInstance

		Returns: the active instance of this singleton object
		Purpose: This gets the active instance, and if it has not already been set, creates
			a new EnemyFactory and sets the instance.
	*/
	public static EnemyFactory GetInstance()
	{
		lock (mutex)
		{
			if (instance == null)
				instance = new EnemyFactory();
			return instance;
		}
	}

	/*
		RegisterEnemy

		Parameters: The prefab to register, the name of this object to be stored under
		Purpose: Adds a new registered prefab to this factory object
	*/
	public void RegisterEnemy(GameObject prefab, string enemyName)
	{
		lock (mutex)
		{
			storedEnemyPrefabs.Add(prefab);
			storedEnemyPrefabKeys[enemyName] = storedEnemyPrefabs.Count - 1;
		}
	}

	/*
		RegisterEnemy

		Parameters: the path of the prefab in the resources directory, the name of this enemy to be stored under
		Purpose: Adds a new registered prefab to this factory object
	*/
	public void RegisterEnemy(string prefab, string enemyName)
	{
		GameObject gameObject = (GameObject)Resources.Load(prefab, typeof(GameObject));
		RegisterEnemy(gameObject, enemyName);
	}

	/*
		Create

		Parameters: the position where the new GameObject should be set to, the name of the enemy to be created
		Purpose: Creates a new GameObject of the given name at the given location
	*/
	public void Create(Vector2 position, string enemyName)
	{
		lock (mutex)
		{
			int prefabIndex = 0;

			// Attempt to get an index for the given string
			if (storedEnemyPrefabKeys.ContainsKey(enemyName))
			{
				prefabIndex = storedEnemyPrefabKeys[enemyName];
				// Then create a new GameObject at this given position
				GameObject prefab = storedEnemyPrefabs[prefabIndex];
				MonoBehaviour.Instantiate(prefab, position, Quaternion.identity);
				EnemyManager.GetInstance().AddEnemy(prefab);
			}
			else
			{
				Debug.Log("Failed to create new enemy " + enemyName);
				return;
			}
		}
	}

	/*
		Create

		Parameters: the position where the new GameObject should be set to
		Purpose: Creates a new random GameObject of the registered types at the given location
	*/
	public void Create(Vector2 position)
	{
		lock (mutex)
		{
			int prefabIndex = 0;

			// Attempt to get an index for the given string
			if (storedEnemyPrefabs.Count == 0)
			{
				Debug.Log("No enemy prefabs stored");
			}
			else
			{
				// get a random index
				prefabIndex = Random.Range(0, storedEnemyPrefabs.Count);

				// Then create a new GameObject at this given position
				GameObject prefab = storedEnemyPrefabs[prefabIndex];
				MonoBehaviour.Instantiate(prefab, position, Quaternion.identity);
				EnemyManager.GetInstance().AddEnemy(prefab);
			}
		}
	}
}
