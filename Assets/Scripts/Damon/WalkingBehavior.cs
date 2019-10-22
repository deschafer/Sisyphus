using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingBehavior : MovementComponent
{
	public WalkingBehavior(Enemy entity) :
		base(entity)
	{
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	public override bool Act()
	{
		if (base.Act())
		{

			// adds a movement to the parent entity
			parentEntity.rigidbody2D.AddForce(Vector2.left, ForceMode2D.Impulse);

			return true;
		}

		return false;
	}
}
