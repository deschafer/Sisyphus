using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Mary
    {
        [Test]
        public void PowerupSpawned()
        {
            Vector3 PowerupPosition = GameObject.Find("Powerup").transform.position;
            Assert.IsNotNull(PowerupPosition);
            //Debug.Log("Powerup did not spawn");
        }

    }
}