using MIDI.Note;
using UnityEngine;
using UnityEngine.InputSystem;
namespace MIDI.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private KeyObject[] _keyObjects;
        private PlayerInput _playerInput;
        private GameManager _gameManager;
        private void Awake()
        {
            _gameManager = GameManager.Instance;
            _playerInput = new PlayerInput();
        }
        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.A.performed += AReadInput;
            _playerInput.Player.S.performed += SReadInput;
            _playerInput.Player.D.performed += DReadInput;
            _playerInput.Player.F.performed += FReadInput;
            _playerInput.Player.G.performed += GReadInput;
            _playerInput.Player.H.performed += HReadInput;
            _playerInput.Player.Space.performed += SpaceReadInput;
        }


        private void OnDisable()
        {
            _playerInput.Player.A.performed -= AReadInput;
            _playerInput.Player.S.performed -= SReadInput;
            _playerInput.Player.D.performed -= DReadInput;
            _playerInput.Player.F.performed -= FReadInput;
            _playerInput.Player.G.performed -= GReadInput;
            _playerInput.Player.H.performed -= HReadInput;
            _playerInput.Player.Space.performed -= SpaceReadInput;
            _playerInput.Disable();
        }

        private void SpaceReadInput(InputAction.CallbackContext context)
        {
            _gameManager.ReStart();
        }
        private void AReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[0].KeyPress();
        }
        private void SReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[1].KeyPress();
        }
        private void DReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[2].KeyPress();
        }
        private void FReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[3].KeyPress();
        }

        private void GReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[4].KeyPress();
        }

        private void HReadInput(InputAction.CallbackContext context)
        {
            _keyObjects[5].KeyPress();
        }
    }
}
