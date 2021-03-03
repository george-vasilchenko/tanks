using System.Collections.Generic;
using Tanks.App.Globals;
using Tanks.App.Inputs;
using Tanks.App.Players;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Lobbies
{
    public class Lobby : MonoBehaviour
    {
        [SerializeField] private PlayerJoinedGameChannel playerJoinedGameChannel;

        [SerializeField] private PlayerJoinedLobbyChannel playerJoinedLobbyChannel;

        [SerializeField] private LobbyContentRequestChannel lobbyContentRequestChannel;

        [SerializeField] private LobbyContentResponseChannel lobbyContentResponseChannel;

        private List<IPlayer> profiles;

        private void Awake()
        {
            this.profiles = new List<IPlayer>(4);
        }

        private void OnEnable()
        {
            this.playerJoinedGameChannel.OnInvoked += this.AddPlayer;
            this.lobbyContentRequestChannel.OnInvoked += this.OnContentRequestHandler;
        }

        private void OnDisable()
        {
            this.playerJoinedGameChannel.OnInvoked -= this.AddPlayer;
            this.lobbyContentRequestChannel.OnInvoked -= this.OnContentRequestHandler;
        }

        private void OnContentRequestHandler()
        {
            this.lobbyContentResponseChannel.Broadcast(this.profiles);
        }

        private void AddPlayer(PlayerInput playerInput)
        {
            playerInput.transform.SetParent(this.transform);
            
            var player = playerInput.GetComponent<IPlayer>();
            player.SetId(playerInput.user.id);
            player.SwitchToInput(ActionMapNames.Ui);
            player.SetDeviceId(playerInput.devices[0].deviceId);
            
            this.profiles.Add(player);
            this.playerJoinedLobbyChannel.Broadcast(player);
        }
    }
}