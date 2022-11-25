using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MIDIFileConvert
{
    public List<MIDIDataModel> NoteList = new List<MIDIDataModel>();
    public void ConvertToData(string pathMIDI)
    {
        string path = Application.dataPath + pathMIDI;
        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            MidiFile midiFile = new MidiFile(stream);

            var ticksPerQuarterNote = midiFile.TicksPerQuarterNote;

            foreach (var track in midiFile.Tracks)
            {
                foreach (var midiEvent in track.MidiEvents)
                {
                    if (midiEvent.MidiEventType == MidiEventType.NoteOn)
                    {
                        NoteList.Add(new MIDIDataModel(midiEvent.Time / (ticksPerQuarterNote * 2f), ConvertToInputKey(midiEvent.Note)));
                    }
                }
            }
        }
        else
        {
            Debug.Log("File not found.");
        }
    }

    private NoteType ConvertToInputKey(int midiValue)
    {
        switch (midiValue)
        {
            case 37:
                return NoteType.cS2;
            case 49:
                return NoteType.cS3;
            case 38:
                return NoteType.d2;
            case 36:
                return NoteType.c2;
            case 48:
                return NoteType.c3;
            case 43:
                return NoteType.g2;
            default:
                return NoteType.none;
        }
    }
}
