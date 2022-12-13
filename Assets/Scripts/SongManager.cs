using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using UnityEngine.UI;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance;
    public AudioSource audioSource;
    public laneManager[] lanes;
    public float songDelayInSeconds;
    public double marginOfError;

    public int inputDelayInMilliseconds;

    public string fileLocation = "DrumTrack1.mid";
    public float noteTime;
    public float noteSpawnY;
    public float noteTapY;

    private Text restartText;

    [Range(1f, 3f)]
    public float songSpeed;

    public float noteDespawnY
    {
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    public static MidiFile midiFile;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        restartText = GameObject.Find("restart_text").GetComponent<Text>();
        Text[] texts = GameObject.Find("Input_text").GetComponentsInChildren<Text>();

        int counter = 0;

        foreach (Text text in texts)
        {
            text.GetComponentInParent<Image>().color = lanes[counter].customPrefab.prefabColor;
            text.text = lanes[counter].inputkey.ToString();
            counter++;
        }

        ReadFromFile();
    }

    public void ReadFromFile()
    {
        midiFile = MidiFile.Read(Application.dataPath + $"/Assetdata/Midi/{fileLocation}");
        GetDataFromMidi();
    }

    public void GetDataFromMidi()
    {
        var notes = midiFile.GetNotes();

        var array = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];
        notes.CopyTo(array, 0);

        foreach (var lane in lanes) lane.SetTimeStamps(array);

        Invoke(nameof(StartSong), songDelayInSeconds);
    }
    public void StartSong()
    {
        scoreManager.scoreTotal = 0;
        Instance.audioSource.pitch = songSpeed;
        audioSource.Play();
    }
    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            restartText.enabled = true;
            if(Input.GetKeyDown(KeyCode.Space)) GetDataFromMidi();
        }
        else
        {
            restartText.enabled = false;
        }
    }
}
