using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace Tanks.App.Inputs
{
    [CreateAssetMenu(fileName = "GameInputAdapter", menuName = "App/Input/GameInputAdapter", order = 0)]
    public class GameInputAdapter : ScriptableObject, Controls.IGameActions
    {
        private Controls controls;

        private Controls Controls => this.controls ??= new Controls();

        private void OnEnable()
        {
            this.Controls.Game.SetCallbacks(this);
            this.Controls.Enable();
        }

        private void OnDisable()
        {
            this.Controls.Disable();
        }

        void Controls.IGameActions.OnMove(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId))
            {
                if (context.performed)
                {
                    this.OnMovePerformed?.Invoke(userId, context.ReadValue<Vector2>());
                }

                if (context.canceled)
                {
                    this.OnMoveCanceled?.Invoke(userId);
                }
            }
        }

        void Controls.IGameActions.OnLook(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId))
            {
                if (context.performed)
                {
                    this.OnLookPerformed?.Invoke(userId, context.ReadValue<float>());
                }
                
                if (context.canceled)
                {
                    this.OnLookCanceled?.Invoke(userId);
                }
            }
        }

        void Controls.IGameActions.OnFire(InputAction.CallbackContext context)
        {
            if (IsUserRegistered(context.control.device, out var userId) && context.performed)
            {
                this.OnFire?.Invoke(userId);
            }
        }

        private static bool IsUserRegistered(InputDevice device, out uint userId)
        {
            var user = InputUser.FindUserPairedToDevice(device);
            userId = user?.id ?? 999;
            return user.HasValue;
        }
        
        public event Action<uint, Vector2> OnMovePerformed;

        public event Action<uint> OnMoveCanceled;

        public event Action<uint, float> OnLookPerformed;

        public event Action<uint> OnLookCanceled;

        public event Action<uint> OnFire;
    }
}