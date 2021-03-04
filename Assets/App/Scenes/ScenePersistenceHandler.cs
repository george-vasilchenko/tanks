using System.Collections.Generic;
using Tanks.App.Lobbies;
using Tanks.App.Players;
using UnityEngine;

namespace Tanks.App.Scenes
{
    [CreateAssetMenu(fileName = "ScenePersistenceHandler", menuName = "App/Scenes/ScenePersistenceHandler", order = 0)]
    public class ScenePersistenceHandler : ScriptableObject
    {
        [SerializeField] private RestartGameChannel restartGameChannel;
        [SerializeField] private PlayerJoinedLobbyChannel playerJoinedLobbyChannel;

        private Dictionary<uint, int> playersDevices;

        public Dictionary<uint, int> PlayersDevices => this.playersDevices ??= new Dictionary<uint, int>();

        private void OnEnable()
        {
            this.playerJoinedLobbyChannel.OnInvoked += this.OnPlayerJoinedLobbyHandler;
            this.restartGameChannel.OnInvoked += this.OnRestartGameChannelHandler;
        }

        private void OnDisable()
        {
            this.playerJoinedLobbyChannel.OnInvoked -= this.OnPlayerJoinedLobbyHandler;
            this.restartGameChannel.OnInvoked -= this.OnRestartGameChannelHandler;
        }

        private void OnRestartGameChannelHandler()
        {
            this.PlayersDevices.Clear();
        }

        private void OnPlayerJoinedLobbyHandler(IPlayer gamePlayer)
        {
            this.PlayersDevices.Add(gamePlayer.Id, gamePlayer.DeviceId);
        }
    }
}