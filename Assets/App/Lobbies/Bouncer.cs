using Tanks.App.Globals;
using Tanks.App.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Tanks.App.Lobbies
{
    public class Bouncer : MonoBehaviour
    {
        [SerializeField] private PlayerJoinedGameChannel playerJoinedGameChannel;

        [SerializeField] private PlayerInputManager playerInputManager;

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += this.OnActiveSceneChangedHandler;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= this.OnActiveSceneChangedHandler;
        }

        private void OnActiveSceneChangedHandler(Scene from, Scene to)
        {
            switch (to.name)
            {
                case SceneNames.Menu:
                    this.playerInputManager.EnableJoining();
                    break;
                case SceneNames.Game:
                    this.playerInputManager.DisableJoining();
                    break;
            }
        }

        public void OnPlayerJoined(PlayerInput playerInput)
        {
            this.playerJoinedGameChannel.Broadcast(playerInput);
        }
    }
}