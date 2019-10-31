using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
	private SortedDictionary<string, int> storedEnemyPrefabKeys;
	public List<GameObject> storedEnemyPrefabs;   

	// Start is called before the first frame update
	void Start()
	{
		storedEnemyPrefabKeys = new SortedDictionary<string, int>();
		storedEnemyPrefabs = new List<GameObject>();
	}

	public void Create(Vector2 position, string enemyName)
	{
		int prefabIndex = 0;

		if (storedEnemyPrefabKeys.ContainsKey(enemyName))
		{
			prefabIndex = storedEnemyPrefabKeys[enemyName];
		}
		else
		{
			Debug.Log("Failed to create new enemy " + enemyName);
			return;
		}

		GameObject prefab = storedEnemyPrefabs[prefabIndex];
		
		Instantiate(prefab, position, Quaternion.identity);
	}

}
