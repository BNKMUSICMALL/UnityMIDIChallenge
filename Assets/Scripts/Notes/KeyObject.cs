using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace MIDI.Note
{
    public class KeyObject : MonoBehaviour
    {
        [SerializeField] private Image _bgImage;
        [SerializeField] private BoxCollider2D _boxCollider2D;
        [SerializeField] private Color _colorPrimary;
        [SerializeField] private Color _colorPress;
        [SerializeField] private float _timePress;

        public void KeyPress()
        {
            StartCoroutine(KeyPress_Coroutine());
        }
        private IEnumerator KeyPress_Coroutine()
        {
            _bgImage.color = _colorPress;
            _boxCollider2D.enabled = true;
            _boxCollider2D.isTrigger = true;
            yield return new WaitForSeconds(_timePress);
            _bgImage.color = _colorPrimary;
            _boxCollider2D.enabled = false;
            _boxCollider2D.isTrigger = false;
        }
    }
}
