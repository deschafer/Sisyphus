using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Dylan
    {
        [Test]
        public void PowerupSpawned()
        {
            Vector3 UIPosition = GameObject.Find("UI").transform.position;
            Assert.IsNotNull(UIPosition);
            //Debug.Log("UI did not spawn");
        }

    }
}
