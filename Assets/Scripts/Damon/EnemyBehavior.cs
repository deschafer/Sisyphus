using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyBehavior : MonoBehaviour
{
	[SerializeField] private Enemy parentEntity = null;		// the object where this behavior is added to

	public EnemyBehavior(Enemy gameEntity)
	{
		ParentEntity = gameEntity;
	}

	//
	// Act();
	// This is where this component creates/adds its behavior to its 
	// parent GameEntity
	//
	abstract public bool Act();

	public Enemy ParentEntity { get => parentEntity; set => parentEntity = value; }
}
