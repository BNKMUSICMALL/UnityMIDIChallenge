// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""3ca2ea84-dced-4941-a1e6-34382232ea06"",
            ""actions"": [
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""ec56884a-17e3-48c2-8662-fdd1e6b143ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""57484561-29fc-4bf8-85f5-f2a5880a79dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""f3cd8405-feb3-46ba-b1f8-782267afa37b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""b4fff97c-82e9-4c0a-a278-ccfd24e72065"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""G"",
                    ""type"": ""Button"",
                    ""id"": ""65f03738-4c11-4c5c-a98d-96de686536d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""H"",
                    ""type"": ""Button"",
                    ""id"": ""1594c790-4bd1-4fd1-ba06-5133c80b031f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""ef9d9992-ff89-4e21-aee3-4d92cc96a350"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4752f38c-513a-4687-a5c0-25538f3f8090"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90e4c523-7ec4-45a6-9126-28245cee6d76"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d60debd6-c05e-41dd-91ba-0e8d8bb84f30"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc7ab155-4757-4c32-881d-a6f0ec5cf6db"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7ab5a2c-de18-4d2e-84b6-626154777e4b"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""G"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b3a29e4a-293f-452d-a4ee-348bdc4f7f85"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""H"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b85d060-5d5d-428c-8bab-c9852937d88b"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_A = m_Player.FindAction("A", throwIfNotFound: true);
        m_Player_S = m_Player.FindAction("S", throwIfNotFound: true);
        m_Player_D = m_Player.FindAction("D", throwIfNotFound: true);
        m_Player_F = m_Player.FindAction("F", throwIfNotFound: true);
        m_Player_G = m_Player.FindAction("G", throwIfNotFound: true);
        m_Player_H = m_Player.FindAction("H", throwIfNotFound: true);
        m_Player_Space = m_Player.FindAction("Space", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_A;
    private readonly InputAction m_Player_S;
    private readonly InputAction m_Player_D;
    private readonly InputAction m_Player_F;
    private readonly InputAction m_Player_G;
    private readonly InputAction m_Player_H;
    private readonly InputAction m_Player_Space;
    public struct PlayerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @A => m_Wrapper.m_Player_A;
        public InputAction @S => m_Wrapper.m_Player_S;
        public InputAction @D => m_Wrapper.m_Player_D;
        public InputAction @F => m_Wrapper.m_Player_F;
        public InputAction @G => m_Wrapper.m_Player_G;
        public InputAction @H => m_Wrapper.m_Player_H;
        public InputAction @Space => m_Wrapper.m_Player_Space;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @A.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnA;
                @S.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnS;
                @D.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnD;
                @F.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnF;
                @F.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnF;
                @F.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnF;
                @G.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnG;
                @G.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnG;
                @G.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnG;
                @H.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnH;
                @H.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnH;
                @H.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnH;
                @Space.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSpace;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
                @F.started += instance.OnF;
                @F.performed += instance.OnF;
                @F.canceled += instance.OnF;
                @G.started += instance.OnG;
                @G.performed += instance.OnG;
                @G.canceled += instance.OnG;
                @H.started += instance.OnH;
                @H.performed += instance.OnH;
                @H.canceled += instance.OnH;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnA(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
        void OnG(InputAction.CallbackContext context);
        void OnH(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
    }
}
