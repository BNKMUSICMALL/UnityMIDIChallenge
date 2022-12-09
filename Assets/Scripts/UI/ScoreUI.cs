using TMPro;
using UnityEngine;
using DG.Tweening;
namespace MIDI.UI
{
    public class ScoreUI : MonoBehaviour
    {
        [Header("Animation Prop")]
        [SerializeField] private Vector3 _scaleEndValue;
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;

        [Space]

        [SerializeField] private TMP_Text _valueText;
        [SerializeField] private int _scoreValue;

        private Tween _tweenScore;

        public void IncreasesScore(int value)
        {
            _scoreValue += value;
            _valueText.text = _scoreValue.ToString();
            ScoreAnimation();
        }
        private void ScoreAnimation()
        {
            _tweenScore.Kill();
            _tweenScore = _valueText.transform.DOScale(_scaleEndValue,_duration).SetEase(_ease).OnComplete(() =>
            {
                _valueText.transform.DOScale(Vector3.one,_duration/4);
            });
        }
        public void ReStartScore()
        {
            _scoreValue = 0;
            _valueText.text = _scoreValue.ToString();
        }
    }
}
