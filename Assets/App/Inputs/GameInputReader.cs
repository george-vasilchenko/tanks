using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Inputs
{
    [RequireComponent(typeof(PlayerInput))]
    public class GameInputReader : MonoBehaviour
    {
        private IGameInputReceiver inputReceiver;
        private InputAction onFireAction;
        private InputAction onLookAction;
        private InputAction onMoveAction;
        private PlayerInput playerInput;

        private void Awake()
        {
            this.playerInput = this.GetComponent<PlayerInput>();
            this.onMoveAction = this.playerInput.actions["move"];
            this.onLookAction = this.playerInput.actions["look"];
            this.onFireAction = this.playerInput.actions["fire"];
        }

        private void Update()
        {
            this.UpdateInputReceiver();
        }

        public void SetReceiver(IGameInputReceiver receiver)
        {
            this.inputReceiver = receiver;
        }

        private void UpdateInputReceiver()
        {
            if (this.inputReceiver == null)
            {
                return;
            }

            if (this.onFireAction.triggered)
            {
                this.inputReceiver.Fire();
            }

            this.inputReceiver.Move(this.onMoveAction.ReadValue<Vector2>());
            this.inputReceiver.Look(this.onLookAction.ReadValue<Vector2>());
        }
    }
}