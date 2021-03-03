using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace Tanks.App.Inputs
{
    [CreateAssetMenu(fileName = "GameInputAdapter", menuName = "App/Input/GameInputAdapter", order = 0)]
    public class GameInputAdapter : ScriptableObject
    {
        private Controls controls;

        private Controls Controls => this.controls ??= new Controls();

        private void OnEnable()
        {
            this.Controls.Game.Pause.performed += this.OnPauseHandler;
            this.Controls.Enable();
        }

        private void OnDisable()
        {
            this.Controls.Game.Pause.performed -= this.OnPauseHandler;
            this.Controls.Disable();
        }

        public event Action OnPause;

        private void OnPauseHandler(InputAction.CallbackContext context)
        {
            if (InputUser.FindUserPairedToDevice(context.control.device).HasValue)
            {
                this.OnPause?.Invoke();
            }
        }
    }
}