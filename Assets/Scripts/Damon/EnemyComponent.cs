using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyComponent : MonoBehaviour
{
	protected GameEntity parentEntity = null;

	public EnemyComponent(GameEntity gameEntity)
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
	abstract public void Act();

}
