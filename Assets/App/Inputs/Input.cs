using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Inputs
{
    public class Input : MonoBehaviour
    {
        [SerializeField] private PlayerJoinedGameChannel playerJoinedGameChannel;

        public void OnPlayerJoined(PlayerInput playerInput)
        {
            this.playerJoinedGameChannel.Broadcast(playerInput);
        }
    }
}