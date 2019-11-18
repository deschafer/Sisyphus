using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Damon
    {
        [Test]
        public void EnemySpawned()
        {
            Vector3 EnemyPosition = GameObject.Find("Enemy").transform.position;
            Assert.IsNotNull(EnemyPosition);
            //Debug.Log("Enemy did not spawn");
        }
    }
}
