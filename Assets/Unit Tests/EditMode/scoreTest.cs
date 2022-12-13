using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class scoreTest
{
    laneManager[] lanes = GameObject.FindObjectsOfType<laneManager>();


    // A Test behaves as an ordinary method
    [Test]
    public void scoreTestSimplePasses()
    {
        // Use the Assert class to test conditions

        for(int i = 0; i < lanes.Length; i++)
        {
            Assert.Greater(lanes[i].score, 0);
        }
    }

    [Test]
    public void noteValueIsNotEmpty()
    {
        // Use the Assert class to test conditions

        for (int i = 0; i < lanes.Length; i++)
        {
            Assert.Greater(lanes[i].notevalue, 0);
        }
    }

}
