using System.Collections.Generic;
using Tanks.App.Lobbies;
using Tanks.App.Players;
using UnityEngine;

namespace Tanks.App.Games
{
    public class GameMode : MonoBehaviour
    {
        [SerializeField] private LobbyContentRequestChannel lobbyContentRequestChannel;

        [SerializeField] private LobbyContentResponseChannel lobbyContentResponseChannel;

        private IEnumerable<IPlayer> players;

        private void Start()
        {
            this.lobbyContentRequestChannel.Broadcast();
        }

        private void OnEnable()
        {
            this.lobbyContentResponseChannel.OnInvoked += this.OnLobbyContentResponseHandler;
        }

        private void OnDisable()
        {
            this.lobbyContentResponseChannel.OnInvoked -= this.OnLobbyContentResponseHandler;
        }

        private void OnLobbyContentResponseHandler(IEnumerable<IPlayer> players)
        {
            this.players = players;
            foreach (var player in this.players)
            {
                player.InitializeGame();
            }
        }
    }
}