using Tanks.App.Inputs;
using Tanks.App.Tanks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Players
{
    public interface IPlayer
    {
        uint Id { get; }

        void InitializeUi(uint id, Transform parent);

        void InitializeGame();

        void Reset();
    }

    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private GameInputAdapter gameInputAdapter;

        [SerializeField] private TankCreator tankCreator;

        [SerializeField] private PlayerInput playerInput;

        private Tank tank;

        private void OnEnable()
        {
            this.gameInputAdapter.OnFire += this.OnFireHandler;
            this.gameInputAdapter.OnMovePerformed += this.OnMovePerformedHandler;
            this.gameInputAdapter.OnMoveCanceled += this.OnMoveCanceledHandler;
            this.gameInputAdapter.OnLookPerformed += this.OnLookPerformedHandler;
        }

        private void OnDisable()
        {
            this.gameInputAdapter.OnFire -= this.OnFireHandler;
            this.gameInputAdapter.OnMovePerformed -= this.OnMovePerformedHandler;
            this.gameInputAdapter.OnMoveCanceled -= this.OnMoveCanceledHandler;
            this.gameInputAdapter.OnLookPerformed -= this.OnLookPerformedHandler;
        }

        public void Reset()
        {
        }

        public uint Id { get; private set; }

        public void InitializeUi(uint id, Transform parent)
        {
            this.Id = id;
            this.gameObject.name = $"Player_{this.Id}";
            this.transform.SetParent(parent);
            // this.playerInput.defaultActionMap = "UI";
        }

        public void InitializeGame()
        {
            // this.playerInput.defaultActionMap = "Game";
            this.tank = this.tankCreator.Create(0, this.Id);
        }

        private void OnMoveCanceledHandler(uint playerId)
        {
            if (this.Id != playerId)
            {
                return;
            }

            this.tank.Move(Vector2.zero);
        }

        private void OnFireHandler(uint playerId)
        {
            if (this.Id != playerId)
            {
                return;
            }

            this.tank.Fire();
        }

        private void OnMovePerformedHandler(uint playerId, Vector2 value)
        {
            if (this.Id != playerId)
            {
                return;
            }

            this.tank.Move(value);
        }

        private void OnLookPerformedHandler(uint playerId, float value)
        {
            if (this.Id != playerId)
            {
                return;
            }

            this.tank.Look(value);
        }
    }
}