using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory
{
	public static EnemyFactory instance;								// singleton instance reference
	private SortedDictionary<string, int> storedEnemyPrefabKeys;		// hash table used to store indicies in the list for enemyName's
	public List<GameObject> storedEnemyPrefabs;							// used to store the prefabs for the registered enemies
	private static readonly object mutex = new object();                // used for locking and mutual exclusion

	private EnemyFactory()
	{
		storedEnemyPrefabKeys = new SortedDictionary<string, int>();
		storedEnemyPrefabs = new List<GameObject>();

		// We register the enemies used
		RegisterEnemy("LightBandit", "LightBandit");
	}

	public static EnemyFactory GetInstance()
	{
		lock (mutex)
		{
			if (instance == null)
				instance = new EnemyFactory();
			return instance;
		}
	}

	public void RegisterEnemy(GameObject prefab, string enemyName)
	{
		lock (mutex)
		{
			storedEnemyPrefabs.Add(prefab);
			storedEnemyPrefabKeys[enemyName] = storedEnemyPrefabs.Count - 1;
		}
	}

	public void RegisterEnemy(string prefab, string enemyName)
	{
		GameObject gameObject = (GameObject)Resources.Load(prefab, typeof(GameObject));
		RegisterEnemy(gameObject, enemyName);
	}

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
