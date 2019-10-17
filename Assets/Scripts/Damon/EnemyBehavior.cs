using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehavior : MonoBehaviour
{
	public Enemy parentEntity = null;

	public EnemyBehavior(Enemy gameEntity)
	{
		parentEntity = gameEntity;
	}

	void Start()
	{
	}

	//
	// Act();
	// This is where this component creates/adds its behavior to its 
	// parent GameEntity
	//
	abstract public bool Act();

}
