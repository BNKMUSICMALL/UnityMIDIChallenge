using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class InputTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void InputTestSimplePasses()
    {
        // Use the Assert class to test conditions
        SongManager sm = GameObject.FindObjectOfType<SongManager>();
        Assert.IsTrue(sm.fileLocation.Contains(".mid"));
    }

    [Test]
    public void NotSameInputTestSimplePasses()
    {
        // Use the Assert class to test conditions
        laneManager[] lanes = GameObject.Find("noteLanes").GetComponentsInChildren<laneManager>();
        bool isUnique = true;
        for(int i = 0; i < lanes.Length; i++)
        {
            string input = lanes[i].inputkey.ToString();
            for (int j = i + 1 ; j < lanes.Length; j++)
            {
                if (lanes[j].inputkey.ToString().Contains(input)) isUnique = false;
            }
        }
        Assert.IsTrue(isUnique);
    }
}
