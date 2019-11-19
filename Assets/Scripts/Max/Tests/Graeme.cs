using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Graeme
    {
        [Test]
        public void PowerupSpawned()
        {
            Vector3 GroundPosition = GameObject.Find("Ground").transform.position;
            Assert.IsNotNull(GroundPosition);
            //Debug.Log("ground did not spawn");
        }

    }
}
