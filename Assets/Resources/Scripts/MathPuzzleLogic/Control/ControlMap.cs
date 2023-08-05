//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Resources/Scripts/MathPuzzleLogic/Control/ControlMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace MathPuzzleLogic.Control
{
	public partial class @ControlMap : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @ControlMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""493bf6fe-8839-42e9-a23a-9b87ecaeb641"",
            ""actions"": [
                {
                    ""name"": ""MoveLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f60ede55-bb61-418c-9bd6-5b1e5c7a5e6d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveRight"",
                    ""type"": ""Button"",
                    ""id"": ""4ac94d54-7138-4877-8974-6bb7025a7ecf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftUp"",
                    ""type"": ""Button"",
                    ""id"": ""312468ff-d3c3-4a9c-8736-ef17a5500d0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftDown"",
                    ""type"": ""Button"",
                    ""id"": ""60450825-3f52-4b9a-9ab5-ab575bb69e01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ac7442cb-7fd7-4b2f-be9d-6b32a2014f68"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cec59237-ba33-44b0-9c8b-41d791403a40"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MoveRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""908a5758-12d2-467d-98aa-9bd77bf38d2f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShiftUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8485761-1f35-41e4-ba29-78b7de4571d5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ShiftDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_MoveLeft = m_Player.FindAction("MoveLeft", throwIfNotFound: true);
            m_Player_MoveRight = m_Player.FindAction("MoveRight", throwIfNotFound: true);
            m_Player_ShiftUp = m_Player.FindAction("ShiftUp", throwIfNotFound: true);
            m_Player_ShiftDown = m_Player.FindAction("ShiftDown", throwIfNotFound: true);
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
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_MoveLeft;
        private readonly InputAction m_Player_MoveRight;
        private readonly InputAction m_Player_ShiftUp;
        private readonly InputAction m_Player_ShiftDown;
        public struct PlayerActions
        {
            private @ControlMap m_Wrapper;
            public PlayerActions(@ControlMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveLeft => m_Wrapper.m_Player_MoveLeft;
            public InputAction @MoveRight => m_Wrapper.m_Player_MoveRight;
            public InputAction @ShiftUp => m_Wrapper.m_Player_ShiftUp;
            public InputAction @ShiftDown => m_Wrapper.m_Player_ShiftDown;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @MoveLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @MoveLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveLeft;
                    @MoveRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @MoveRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @MoveRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoveRight;
                    @ShiftUp.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftUp;
                    @ShiftUp.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftUp;
                    @ShiftUp.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftUp;
                    @ShiftDown.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftDown;
                    @ShiftDown.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftDown;
                    @ShiftDown.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShiftDown;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MoveLeft.started += instance.OnMoveLeft;
                    @MoveLeft.performed += instance.OnMoveLeft;
                    @MoveLeft.canceled += instance.OnMoveLeft;
                    @MoveRight.started += instance.OnMoveRight;
                    @MoveRight.performed += instance.OnMoveRight;
                    @MoveRight.canceled += instance.OnMoveRight;
                    @ShiftUp.started += instance.OnShiftUp;
                    @ShiftUp.performed += instance.OnShiftUp;
                    @ShiftUp.canceled += instance.OnShiftUp;
                    @ShiftDown.started += instance.OnShiftDown;
                    @ShiftDown.performed += instance.OnShiftDown;
                    @ShiftDown.canceled += instance.OnShiftDown;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }

		ReadOnlyArray<InputDevice>? IInputActionCollection.devices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		ReadOnlyArray<InputControlScheme> IInputActionCollection.controlSchemes => throw new NotImplementedException();

		public interface IPlayerActions
        {
            void OnMoveLeft(InputAction.CallbackContext context);
            void OnMoveRight(InputAction.CallbackContext context);
            void OnShiftUp(InputAction.CallbackContext context);
            void OnShiftDown(InputAction.CallbackContext context);
        }
    }
}
