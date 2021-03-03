// GENERATED AUTOMATICALLY FROM 'Assets/ScriptableObj/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using Object = UnityEngine.Object;

namespace Tanks.App.Inputs
{
    public class Controls : IInputActionCollection, IDisposable
    {
        // Game
        private readonly InputActionMap m_Game;
        private readonly InputAction m_Game_Fire;
        private readonly InputAction m_Game_Look;
        private readonly InputAction m_Game_Move;
        private readonly InputAction m_Game_Pause;

        // UI
        private readonly InputActionMap m_UI;
        private readonly InputAction m_UI_Cancel;
        private readonly InputAction m_UI_Start;
        private readonly InputAction m_UI_Submit;
        private IGameActions m_GameActionsCallbackInterface;
        private int m_GamepadSchemeIndex = -1;
        private IUIActions m_UIActionsCallbackInterface;

        public Controls()
        {
            this.asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""497f8b60-a5ce-4b0b-b95e-3aa408ec85d1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d2f873a7-eee9-4cf3-a93b-0456e1e8b70b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""3c9a18ee-e5c6-4f63-ad01-dcee68cb3f97"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d1c9f7f2-a56a-4148-b8b1-a56628662927"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6ebae894-4f38-4724-be4f-a5a01f424265"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68815bae-306a-4628-bbca-55c673103062"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143bb1cd-cc10-4eca-a2f0-a3664166fe91"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d4de806-98ca-4f94-a5ea-b017ed239962"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a40f8bac-1ec3-4ff5-85ca-27b7458a1901"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""bca56312-9c01-439a-8294-1109b7e9c968"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""45748804-4122-4e29-9933-38714dccaed2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""b006df27-9e3a-4f07-8635-64392b6766b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""b7c7628f-b359-43d2-83ad-ecb5648548bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9e92bb26-7e3b-4ec4-b06b-3c8f8e498ddc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82627dcc-3b13-4ba9-841d-e4b746d6553e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7c2c2f0-92be-43b3-a8b6-aacd43f4b97f"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Game
            this.m_Game = this.asset.FindActionMap("Game", true);
            this.m_Game_Move = this.m_Game.FindAction("Move", true);
            this.m_Game_Look = this.m_Game.FindAction("Look", true);
            this.m_Game_Fire = this.m_Game.FindAction("Fire", true);
            this.m_Game_Pause = this.m_Game.FindAction("Pause", true);
            // UI
            this.m_UI = this.asset.FindActionMap("UI", true);
            this.m_UI_Start = this.m_UI.FindAction("Start", true);
            this.m_UI_Submit = this.m_UI.FindAction("Submit", true);
            this.m_UI_Cancel = this.m_UI.FindAction("Cancel", true);
        }

        public InputActionAsset asset { get; }

        public GameActions Game => new GameActions(this);

        public UIActions UI => new UIActions(this);

        public InputControlScheme GamepadScheme
        {
            get
            {
                if (this.m_GamepadSchemeIndex == -1)
                {
                    this.m_GamepadSchemeIndex = this.asset.FindControlSchemeIndex("Gamepad");
                }

                return this.asset.controlSchemes[this.m_GamepadSchemeIndex];
            }
        }

        public void Dispose()
        {
            Object.Destroy(this.asset);
        }

        public InputBinding? bindingMask
        {
            get => this.asset.bindingMask;
            set => this.asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => this.asset.devices;
            set => this.asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => this.asset.controlSchemes;

        public bool Contains(InputAction action) => this.asset.Contains(action);

        public IEnumerator<InputAction> GetEnumerator() => this.asset.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public void Enable()
        {
            this.asset.Enable();
        }

        public void Disable()
        {
            this.asset.Disable();
        }

        public struct GameActions
        {
            private readonly Controls m_Wrapper;

            public GameActions(Controls wrapper) => this.m_Wrapper = wrapper;

            public InputAction Move => this.m_Wrapper.m_Game_Move;

            public InputAction Look => this.m_Wrapper.m_Game_Look;

            public InputAction Fire => this.m_Wrapper.m_Game_Fire;

            public InputAction Pause => this.m_Wrapper.m_Game_Pause;

            public InputActionMap Get() => this.m_Wrapper.m_Game;

            public void Enable()
            {
                this.Get().Enable();
            }

            public void Disable()
            {
                this.Get().Disable();
            }

            public bool enabled => this.Get().enabled;

            public static implicit operator InputActionMap(GameActions set) => set.Get();

            public void SetCallbacks(IGameActions instance)
            {
                if (this.m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    this.Move.started -= this.m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                    this.Move.performed -= this.m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                    this.Move.canceled -= this.m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                    this.Look.started -= this.m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    this.Look.performed -= this.m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    this.Look.canceled -= this.m_Wrapper.m_GameActionsCallbackInterface.OnLook;
                    this.Fire.started -= this.m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    this.Fire.performed -= this.m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    this.Fire.canceled -= this.m_Wrapper.m_GameActionsCallbackInterface.OnFire;
                    this.Pause.started -= this.m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                    this.Pause.performed -= this.m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                    this.Pause.canceled -= this.m_Wrapper.m_GameActionsCallbackInterface.OnPause;
                }

                this.m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    this.Move.started += instance.OnMove;
                    this.Move.performed += instance.OnMove;
                    this.Move.canceled += instance.OnMove;
                    this.Look.started += instance.OnLook;
                    this.Look.performed += instance.OnLook;
                    this.Look.canceled += instance.OnLook;
                    this.Fire.started += instance.OnFire;
                    this.Fire.performed += instance.OnFire;
                    this.Fire.canceled += instance.OnFire;
                    this.Pause.started += instance.OnPause;
                    this.Pause.performed += instance.OnPause;
                    this.Pause.canceled += instance.OnPause;
                }
            }
        }

        public struct UIActions
        {
            private readonly Controls m_Wrapper;

            public UIActions(Controls wrapper) => this.m_Wrapper = wrapper;

            public InputAction Start => this.m_Wrapper.m_UI_Start;

            public InputAction Submit => this.m_Wrapper.m_UI_Submit;

            public InputAction Cancel => this.m_Wrapper.m_UI_Cancel;

            public InputActionMap Get() => this.m_Wrapper.m_UI;

            public void Enable()
            {
                this.Get().Enable();
            }

            public void Disable()
            {
                this.Get().Disable();
            }

            public bool enabled => this.Get().enabled;

            public static implicit operator InputActionMap(UIActions set) => set.Get();

            public void SetCallbacks(IUIActions instance)
            {
                if (this.m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    this.Start.started -= this.m_Wrapper.m_UIActionsCallbackInterface.OnStart;
                    this.Start.performed -= this.m_Wrapper.m_UIActionsCallbackInterface.OnStart;
                    this.Start.canceled -= this.m_Wrapper.m_UIActionsCallbackInterface.OnStart;
                    this.Submit.started -= this.m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    this.Submit.performed -= this.m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    this.Submit.canceled -= this.m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    this.Cancel.started -= this.m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    this.Cancel.performed -= this.m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    this.Cancel.canceled -= this.m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                }

                this.m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    this.Start.started += instance.OnStart;
                    this.Start.performed += instance.OnStart;
                    this.Start.canceled += instance.OnStart;
                    this.Submit.started += instance.OnSubmit;
                    this.Submit.performed += instance.OnSubmit;
                    this.Submit.canceled += instance.OnSubmit;
                    this.Cancel.started += instance.OnCancel;
                    this.Cancel.performed += instance.OnCancel;
                    this.Cancel.canceled += instance.OnCancel;
                }
            }
        }

        public interface IGameActions
        {
            void OnMove(InputAction.CallbackContext context);

            void OnLook(InputAction.CallbackContext context);

            void OnFire(InputAction.CallbackContext context);

            void OnPause(InputAction.CallbackContext context);
        }

        public interface IUIActions
        {
            void OnStart(InputAction.CallbackContext context);

            void OnSubmit(InputAction.CallbackContext context);

            void OnCancel(InputAction.CallbackContext context);
        }
    }
}