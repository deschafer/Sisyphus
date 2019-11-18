using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Max
	{
        [Test]
        public void PlayerSpawned()
        {
            Vector3 PlayerPosition = GameObject.Find("Player").transform.position;
            Assert.IsNotNull(PlayerPosition);
            //Debug.Log("Powerup did not spawn");
        }

    }
}