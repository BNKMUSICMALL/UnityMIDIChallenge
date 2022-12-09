using MIDI.Manager;
using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace MIDI.Note
{
    public class NoteObject : MonoBehaviour
    {
        [SerializeField] private Image _noteImage;
        [SerializeField] private AudioClip _soundEffect;
        [SerializeField] private Transform _target;
        [SerializeField] private int _scorePoint = 20;
        [SerializeField] private double _timeMove = 0.2f;
        private GameManager _gameManager;
        private Tween _tweenMove;

        public event Action onNoteHit;
        private void Awake()
        {
            _gameManager = GameManager.Instance;
        }
        private void OnEnable() 
        {
            this.transform.localPosition = new Vector3 (0,300,0);
            MoveToTarget();
        }
        private void OnDisable() 
        {
            _tweenMove.Kill();
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if (other.CompareTag("KeyPad"))
            {
                _gameManager.IncreasesScore(_scorePoint);
                _gameManager.PlaySoundEffect(_soundEffect);
                onNoteHit?.Invoke();
                this.gameObject.SetActive(false);
            }
        }
        public void InitNoteObject(Color color,Transform target,AudioClip audioClip)
        {
            _noteImage.color = color;
            _target = target;
            _soundEffect = audioClip;
        }
        private void MoveToTarget()
        {
            if (_target == null)
            {
                return;
            }
            double timeSinceInstantiated = _gameManager.GetAudioSourceTime() - _timeMove;
            float time = (float)(timeSinceInstantiated / (5));
            _tweenMove = this.transform.DOLocalMove(_target.localPosition,time,false).SetEase(Ease.Linear).OnComplete(() => 
            {
                this.gameObject.SetActive(false);
            });
        }
    }
}
