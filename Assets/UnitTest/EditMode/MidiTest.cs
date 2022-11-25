using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MidiTest
{
    [Test]
    public void AddMIDIFile()
    {
        MIDIFileConvert midiFileConvert = new MIDIFileConvert();
        string path = "/AssetData/Midi/DrumTrack1.mid";
        midiFileConvert.ConvertToData(path);
        Assert.AreNotEqual(midiFileConvert.NoteList.Count, 0);
    }

    [Test]
    public void AddWrongMIDIFile()
    {
        MIDIFileConvert midiFileConvert = new MIDIFileConvert();
        string path = "/AssetData/Midi/DrumTrack2.mid";
        midiFileConvert.ConvertToData(path);
        Assert.AreEqual(midiFileConvert.NoteList.Count, 0);
    }

}
