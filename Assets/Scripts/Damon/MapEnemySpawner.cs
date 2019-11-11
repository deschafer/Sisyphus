using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEnemySpawner : MonoBehaviour
{
	private float enemySpawnTimer = 0;
	private float enemySpawnTime = 5.0f;
	private const float spawnY = 3.0f;
	private Vector2 lastPlayerPosition = new Vector2(0,0);
	private float distanceToSpawn = 32.0f;
	private GameObject player;
	private float offset = 5.0f;


	// Start is called before the first frame update
	void Start()
	{
		enemySpawnTimer = 0;
		enemySpawnTime = 5.0f;
		player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame
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
