using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace Tanks.App.Inputs
{
    [CreateAssetMenu(fileName = "UiInputAdapter", menuName = "App/Input/UiInputAdapter", order = 0)]
    public class UiInputAdapter : ScriptableObject, Controls.IUIActions
    {
        private Controls controls;

        private Controls Controls => this.controls ??= new Controls();

        private void OnEnable()
        {
            this.Controls.UI.SetCallbacks(this);
            this.Controls.Enable();
        }

        private void OnDisable()
        {
            this.Controls.Disable();
        }

        void Controls.IUIActions.OnSubmit(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId) && context.performed)
            {
                this.OnSubmit?.Invoke(userId);
            }
        }

        void Controls.IUIActions.OnCancel(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId) && context.performed)
            {
                this.OnCancel?.Invoke(userId);
            }
        }

        void Controls.IUIActions.OnStart(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId) && context.performed)
            {
                this.OnStart?.Invoke(userId);
            }
        }

        private static bool IsUserRegistered(InputDevice device, out uint userId)
        {
            var user = InputUser.FindUserPairedToDevice(device);
            if (!user.HasValue)
            {
                userId = 999;
                return false;
            }

            userId = user.Value.id;
            return true;
        }
        
        private static uint GetUserId(InputAction.CallbackContext context) => InputUser.FindUserPairedToDevice(context.control.device)!.Value.id;
        
        public event Action<uint> OnSubmit;

        public event Action<uint> OnCancel;

        public event Action<uint> OnStart;
    }
}