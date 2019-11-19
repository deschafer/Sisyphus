using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject prefab; // prefab of the enemy that we are spawning
	public string enemyToCreate;
	public int numberEnemies = 50;
	private int count = 0;
	public GameObject player;

	// Update is called once per frame
	void Update()
	{
		if (count++ < numberEnemies)
		{
			EnemyFactory.GetInstance().Create(player.transform.position, enemyToCreate);
		}
	}
}
