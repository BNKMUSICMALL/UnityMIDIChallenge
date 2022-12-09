using MIDI.Manager;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
namespace MIDI.Note
{
    public class Lane : MonoBehaviour
    {
        [SerializeField] private string _noteName;
        [SerializeField] private AudioClip _soundNoteEffect;
        [SerializeField] private NoteObject _noteObjectPrefab;
        [SerializeField] private Color _noteColor;
        [SerializeField] private Transform _targetNote;
        [SerializeField] private Image _lightLinear;
        [SerializeField] private bool _isPlay;
        private int _spawnIndex = 0;
        private double _tempTimeStamp = 0;
        private GameManager _gameManager;
        private List<NoteObject> _notes = new List<NoteObject>();
        private List<double> _timeStamps = new List<double>();

        private void Start()
        {
            _gameManager = GameManager.Instance;
        }
        private void Update()
        {
            if (!_isPlay)
            {
                return;
            }
            if (_spawnIndex < _timeStamps.Count)
            {
                if (_gameManager.GetAudioSourceTime() >= _timeStamps[_spawnIndex] - _gameManager?.NoteTime)
                {
                    _notes[_spawnIndex].gameObject.SetActive(true);
                    _spawnIndex++;
                }
            }
            else
            {
                StopPlay();
            }
        }
        public void StartPlay()
        {
            _isPlay = true;
            _spawnIndex = 0;
        }
        public void StopPlay()
        {
            _isPlay = false;
            _spawnIndex = 0;
        }
        public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note note,MidiFile midiFile)
        {
            if (note.ToString() == _noteName)
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, midiFile.GetTempoMap());
                _tempTimeStamp = (double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f;
                if (_tempTimeStamp != 0)
                {
                    _timeStamps.Add(_tempTimeStamp);
                }
                SpawnNote((float)_tempTimeStamp);
            }
        }
        private void SpawnNote(float timeStamp)
        {
            NoteObject note = Instantiate(_noteObjectPrefab,this.transform);
            note.transform.localPosition = new Vector3(0,300,0);
            note.InitNoteObject(_noteColor,_targetNote,_soundNoteEffect);
            note.onNoteHit += OnNoteHit;
            note.gameObject.SetActive(false);
            note.name = $"{this.gameObject.name}_{timeStamp}";
            _notes.Add(note);
        }
        private void OnNoteHit()
        {
            _lightLinear.DOFade(100,0.2f).OnComplete(() => _lightLinear.DOFade(0,0.2f));
        }
    }
}
