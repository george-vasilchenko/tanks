using System.Collections.Generic;
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

        [SerializeField] private List<Player> players;

        private void Awake()
        {
            this.players = new List<Player>(4);
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
            this.lobbyContentResponseChannel.Broadcast(this.players);
        }

        private void AddPlayer(PlayerInput playerInput)
        {
            playerInput.DeactivateInput();
            var player = playerInput.GetComponent<Player>();
            player.InitializeUi(playerInput.user.id, this.transform);

            this.players.Add(player);
            this.playerJoinedLobbyChannel.Broadcast(player);
        }
    }
}