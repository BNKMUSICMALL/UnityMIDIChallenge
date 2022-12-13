using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.MusicTheory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laneManager : MonoBehaviour
{
    public NoteName notename;
    public int notevalue;
    public KeyCode inputkey;
    public int score = 20;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();
    public Customization customPrefab;


    int spawnIndex = 0;
    int inputIndex = 0;

    [System.Serializable]
    public class Customization
    {
        public Color prefabColor = new Color(0, 0, 0, 255);
        [Range(1f, 3f)]
        public float prefabSize = 1f;
    }

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array)
        {
            if (note.NoteNumber == notevalue)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnIndex < timeStamps.Count)
        {
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                note.GetComponent<SpriteRenderer>().color = customPrefab.prefabColor;
                note.transform.localScale = new Vector3(customPrefab.prefabSize, customPrefab.prefabSize, 1);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.Instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(inputkey))
            {
                if (Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    scoreManager.Hit(score);    
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
            }
            if (timeStamp + marginOfError <= audioTime)
            {
                scoreManager.Miss();
                inputIndex++;
            }
        }
    }
}
