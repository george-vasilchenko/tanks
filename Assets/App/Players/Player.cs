using Tanks.App.Inputs;
using Tanks.App.Tanks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Players
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(GameInputReader))]
    public class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private TankCreator tankCreator;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private GameInputReader gameInputReader;

        private Tank tank;

        public int DeviceId { get; private set; }

        public void Reset()
        {
        }

        public uint Id { get; private set; }

        public void SwitchToInput(string actionMapName)
        {
            this.playerInput.SwitchCurrentActionMap(actionMapName);
        }

        public void CreateTank()
        {
            this.tank = this.tankCreator.Create(0);
            this.gameInputReader.SetReceiver(this.tank);
        }

        public void SetId(uint id)
        {
            this.Id = id;
            this.gameObject.name = $"Player_{this.Id}";
        }

        public void SetDeviceId(int deviceId)
        {
            this.DeviceId = deviceId;
        }
    }
}