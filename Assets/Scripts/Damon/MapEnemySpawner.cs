using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	MapEnemySpawner
	
	Author: Damon Schafer
	Purpose: This object is responsible for spawning enemies periodically 
	as the player moves through the map
*/
public class MapEnemySpawner : MonoBehaviour
{
	private float enemySpawnTimer = 0;						// Timer used to keep track of spawns
	private float enemySpawnTime = 5.0f;					// time needed to spawn
	private const float spawnY = 3.0f;						// y coord of where enemies are spawned
	private Vector2 lastPlayerPosition = new Vector2(0,0);	// used to compare with the last spawn area 
	private float distanceToSpawn = 32.0f;					// the distance the player must travel between spawns
	private GameObject player;								// reference to the player
	private float offset = 5.0f;							// amount of possible difference in the x-coordinate for spawns.

	/*
		Start

		Purpose: Initialize the object, called prior to Update
	*/
	void Start()
	{
		enemySpawnTimer = 0;
		enemySpawnTime = 5.0f;
		player = GameObject.FindGameObjectWithTag("Player");
	}

	/*
		Update

		Purpose: spawns in a number of new enemies if enough time has passed and the player
			has covered enough distance.
	*/
	void Update()
	{
		enemySpawnTimer += Time.deltaTime;

		if (enemySpawnTimer >= enemySpawnTime)
		{
			// get the player's position
			Vector2 playerpos = player.transform.position;
			float offsetX = (Random.Range(0, 1) == 0) ? -Random.Range(0, offset) : Random.Range(0, offset);

			// we only spawn an additional enemy if the player moves far enough
			if (playerpos.x - lastPlayerPosition.x >= distanceToSpawn)
			{
				// reset the timer
				enemySpawnTimer = 0;

				// spawn a new enemy
				EnemyFactory.GetInstance().Create(new Vector2(playerpos.x + offsetX, spawnY));

				lastPlayerPosition = playerpos;
			}
		}
	}
}
