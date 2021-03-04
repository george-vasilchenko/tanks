using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Players
{
    [RequireComponent(typeof(PlayerInput))]
    public class Player : MonoBehaviour, IPlayer
    {
        public int DeviceId { get; private set; }

        public uint Id { get; private set; }

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