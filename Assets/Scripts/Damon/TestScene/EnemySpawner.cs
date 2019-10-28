using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject prefab; // prefab of the enemy that we are spawning
	private const int numberEnemies = 50;
	private int count = 0;

	// Update is called once per frame
	void Update()
	{
		if (count++ < numberEnemies)
			Instantiate(prefab, new Vector2(60, 10), Quaternion.identity);
	}
}
