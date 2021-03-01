using Tanks.App.Lobbies;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.App.Scenes
{
    public class ScenesHandler : MonoBehaviour
    {
        [SerializeField] private LobbyReadyChannel lobbyReadyChannel;

        private void OnEnable()
        {
            this.lobbyReadyChannel.OnInvoked += OnLobbyReady;
        }

        private void OnDisable()
        {
            this.lobbyReadyChannel.OnInvoked -= OnLobbyReady;
        }

        private static void OnLobbyReady()
        {
            SceneManager.LoadScene("Game");
        }
    }
}