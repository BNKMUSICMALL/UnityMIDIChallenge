using MIDI.Note;
using MIDI.UI;
using UnityEngine;
using System.Collections;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;

namespace MIDI.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        private static GameManager _instance;
        public static GameManager Instance 
        { 
            get 
            {
                if (_instance == null)
                {
                    Debug.LogWarning("Input Manager Is Null");
                }
                return _instance;
            }
        }
        #endregion
        [Header("Track FileName")]
        [SerializeField] private string _fileName;

        [Space]
        
        [Header("Scene Ref")]
        [SerializeField] private GameObject _restartPanel;
        [SerializeField] private ScoreUI _scoreUI;
        [SerializeField] private AudioSource _soundBGM;
        [SerializeField] private AudioSource _soundEffect;

        [Space]
        
        [Header("Note Time")]
        [SerializeField] private float _noteTime;
        [SerializeField] private Lane[] _lanes;

        private MidiFile _midiFile;

        public float NoteTime { get => _noteTime;}

        private void Awake()
        {
            _instance = this;
            GetData();
            PlayGame();
        }
        private void PlayGame()
        {
            StartCoroutine(PlayGame_Coroutine());
        }
        private void GetData()
        {
            _midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + _fileName);
            foreach (TrackChunk track in _midiFile.GetTrackChunks())
            {
                foreach (var note in track.GetNotes())
                {
                    foreach (Lane lane in _lanes)
                    {
                        lane.SetTimeStamps(note,_midiFile);
                    }
                }
            }
        }
        private IEnumerator PlayGame_Coroutine()
        {
            yield return new WaitForSeconds(1f);
            _soundBGM.Play();
            foreach (Lane lane in _lanes)
            {
                lane.StartPlay();
            }
            StartCoroutine(ReStart_Coroutine());
        }
        private IEnumerator ReStart_Coroutine()
        {
            yield return new WaitForSeconds(_soundBGM.clip.length + 2f);
            _restartPanel.SetActive(true);
        }
        public void ReStart()
        {
            if (!_restartPanel.activeInHierarchy)
            {
                return;
            }

            PlayGame();
            
            _restartPanel.SetActive(false);
            _scoreUI.ReStartScore();
        }
        public void PlaySoundEffect(AudioClip audioClip)
        {
            _soundEffect.PlayOneShot(audioClip);
        }
        public void IncreasesScore(int value)
        {
            _scoreUI.IncreasesScore(value);
        }
        public double GetAudioSourceTime()
        {
            return (double)_soundBGM.timeSamples / _soundBGM.clip.frequency;
        }
    }
}
