using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class midiFileTest
{
    SongManager sm = GameObject.FindObjectOfType<SongManager>();

    // A Test behaves as an ordinary method
    [Test]
    public void midiFileIsNotEmptyTestSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.IsTrue(System.IO.File.Exists(Application.dataPath + "/Assetdata/Midi/" + sm.fileLocation));
    }

    [Test]
    public void midiFileTypeTestSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.IsTrue(sm.fileLocation.Contains(".mid"));
    }

}
