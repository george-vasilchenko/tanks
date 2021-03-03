using System.Collections.Generic;
using Tanks.App.Globals;
using Tanks.App.Lobbies;
using Tanks.App.Players;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.App.Scenes
{
    public class ScenesHandler : MonoBehaviour
    {
        [SerializeField] private RestartLevelChannel restartLevelChannel;
        [SerializeField] private RestartGameChannel restartGameChannel;
        [SerializeField] private LobbyReadyChannel lobbyReadyChannel;

        private void OnEnable()
        {
            this.restartLevelChannel.OnInvoked += OnRestartLevelHandler;
            this.restartGameChannel.OnInvoked += OnRestartGameHandler;
            this.lobbyReadyChannel.OnInvoked += OnLobbyReady;
        }

        private void OnDisable()
        {
            this.restartLevelChannel.OnInvoked -= OnRestartLevelHandler;
            this.restartGameChannel.OnInvoked -= OnRestartGameHandler;
            this.lobbyReadyChannel.OnInvoked -= OnLobbyReady;
        }

        private static void OnRestartGameHandler()
        {
            SceneManager.LoadScene(SceneNames.Menu);
        }

        private static void OnRestartLevelHandler()
        {
            SceneManager.LoadScene(SceneNames.Game);
        }

        private static void OnLobbyReady()
        {
            SceneManager.LoadScene(SceneNames.Game);
        }
    }
}