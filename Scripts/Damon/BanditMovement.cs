using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditMovement : MovementComponent
{

	public BanditMovement(Enemy entity) :
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
		if (!base.Act())
		{
			return false;
		}

		// If we have made it here, then a waypoint has been set,
		// and this enemy is in a patrol state

		// Then we add a movement to the current position
			// a translation
		// Then we also check if we need to jump to get to our waypoint

		return true;
	}
}
