// GENERATED AUTOMATICALLY FROM 'Assets/Core/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Core.Input
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""0e1fb8ed-59dd-476c-8283-0aa9c4150dd1"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""cddd0bfe-ffb3-4541-9145-c4b1605ac527"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""06b96d3b-8b92-43bd-86e2-dc299a253f84"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""82324fe3-9d78-4110-9b0a-5ebaa041f8a4"",
            ""actions"": [
                {
                    ""name"": ""Unpause"",
                    ""type"": ""Button"",
                    ""id"": ""3353043a-32b9-42ae-9080-47f0373fc7b7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""86bf906b-a747-4fd5-a1cc-ec8a9ced5777"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Unpause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Gameplay
            m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
            m_Gameplay_Pause = m_Gameplay.FindAction("Pause", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Unpause = m_UI.FindAction("Unpause", throwIfNotFound: true);
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

        // Gameplay
        private readonly InputActionMap m_Gameplay;
        private IGameplayActions m_GameplayActionsCallbackInterface;
        private readonly InputAction m_Gameplay_Pause;
        public struct GameplayActions
        {
            private @Controls m_Wrapper;
            public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_Gameplay_Pause;
            public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
            public void SetCallbacks(IGameplayActions instance)
            {
                if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPause;
                }
                m_Wrapper.m_GameplayActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                }
            }
        }
        public GameplayActions @Gameplay => new GameplayActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Unpause;
        public struct UIActions
        {
            private @Controls m_Wrapper;
            public UIActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Unpause => m_Wrapper.m_UI_Unpause;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Unpause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnUnpause;
                    @Unpause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnUnpause;
                    @Unpause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnUnpause;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Unpause.started += instance.OnUnpause;
                    @Unpause.performed += instance.OnUnpause;
                    @Unpause.canceled += instance.OnUnpause;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        public interface IGameplayActions
        {
            void OnPause(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnUnpause(InputAction.CallbackContext context);
        }
    }
}
