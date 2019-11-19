using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
/*
author: Max Moore
purpose: Initiate tests for the test runner, find test cases
parameters: a working game scene
*/
namespace Tests
{
    public class Max
	{
        [Test]
        public void PlayerSpawned()
        {
            Vector3 PlayerPosition = GameObject.Find("Player").transform.position;
            Assert.IsNotNull(PlayerPosition);
            //Debug.Log("Player did not spawn");
        }

    }
}