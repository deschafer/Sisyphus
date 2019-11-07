using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	EnemyBehavior
	
	Author: Damon Schafer
	Purpose: Provides a base class for all behaviors that are added to enemies
*/
abstract public class EnemyBehavior : MonoBehaviour
{
	[SerializeField] private Enemy parentEntity = null;     // the object where this behavior is added to

	/*
		EnemyBehavior

		Parameters: The Enemy that this behavior is attached
		Purpose: creates a new EnemyBehavior
	*/
	public EnemyBehavior(Enemy gameEntity)
	{
		ParentEntity = gameEntity;
	}

	/*
		Act

		Parameters: This is where this component creates/adds its behavior to its parent GameEntity
		Returns: true/false, denotes if the derived class Act method should continue
		Purpose: creates a new Enemy
	*/
	abstract public bool Act();

	/*
		Getter and Setter

		Parameters: Take a value to assign the denoted variable
		Purpose: To assign and get values of private member variables
	*/
	public Enemy ParentEntity { get => parentEntity; set => parentEntity = value; }
}
