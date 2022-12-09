using MIDI.Note;
using UnityEngine;
using UnityEngine.InputSystem;
namespace MIDI.Manager
{
    public class InputManager : MonoBehaviour
    {
        #region Singleton
        private static InputManager _instance;
        public static InputManager Instance 
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
        [SerializeField] private KeyObject[] _buttonUIs;
        private PlayerInput _playerInput;
        private GameManager _gameManager;
        private void Awake()
        {
            _instance = this;
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
            _buttonUIs[0].KeyPress();
        }
        private void SReadInput(InputAction.CallbackContext context)
        {
            _buttonUIs[1].KeyPress();
        }
        private void DReadInput(InputAction.CallbackContext context)
        {
            _buttonUIs[2].KeyPress();
        }
        private void FReadInput(InputAction.CallbackContext context)
        {
            _buttonUIs[3].KeyPress();
        }

        private void GReadInput(InputAction.CallbackContext context)
        {
            _buttonUIs[4].KeyPress();
        }

        private void HReadInput(InputAction.CallbackContext context)
        {
            _buttonUIs[5].KeyPress();
        }
    }
}
