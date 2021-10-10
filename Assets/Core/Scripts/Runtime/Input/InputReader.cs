﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input/InputReader", order = 0)]
    public class InputReader : ScriptableObject, Controls.IGameplayActions, Controls.IUIActions
    {
        private Controls m_Controls;
        public event Action paused;

        private void OnEnable()
        {
            if (m_Controls == null)
            {
                m_Controls = new Controls();
                m_Controls.Gameplay.SetCallbacks(this);
                m_Controls.UI.SetCallbacks(this);
            }
            m_Controls.Enable();
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.performed) paused?.Invoke();
        }

        public void OnUnpause(InputAction.CallbackContext context)
        {
        }
    }
}