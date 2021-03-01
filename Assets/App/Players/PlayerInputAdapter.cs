using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Players
{
    public class PlayerInputAdapter : MonoBehaviour
    {
        public void Move(InputAction.CallbackContext context)
        {
            this.OnMove?.Invoke(context.ReadValue<Vector2>());
        }

        public void Look(InputAction.CallbackContext context)
        {
            this.OnLook?.Invoke(context.ReadValue<Vector2>());
        }

        public void Fire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                this.OnFire?.Invoke();
            }
        }

        public event Action<Vector2> OnMove;

        public event Action<Vector2> OnLook;

        public event Action OnFire;
    }
}