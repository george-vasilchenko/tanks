using System.Collections.Generic;
using Tanks.App.Globals;
using Tanks.App.Inputs;
using Tanks.App.Players;
using Tanks.App.Scenes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Games
{
    public class GameMode : MonoBehaviour
    {
        [SerializeField] private PlayerPrefabContainer playerPrefabContainer;
        [SerializeField] private ScenePersistenceHandler scenePersistenceHandler;
        [SerializeField] private GameInputAdapter gameInputAdapter;
        [SerializeField] private GameObject pauseUi;
        private bool isPaused;
        private IEnumerable<IGamePlayer> players;

        private void Start()
        {
            this.players = this.CreatePlayers();
            this.SetPause(false);
        }

        private void OnEnable()
        {
            this.gameInputAdapter.OnPause += this.OnPauseHandler;
        }

        private void OnDisable()
        {
            this.gameInputAdapter.OnPause -= this.OnPauseHandler;
        }

        private IEnumerable<IGamePlayer> CreatePlayers()
        {
            var playersToCreate = new List<IGamePlayer>();
            foreach (var playerDevice in this.scenePersistenceHandler.PlayersDevices)
            {
                var device = InputSystem.GetDeviceById(playerDevice.Value);
                var playerInput = PlayerInput.Instantiate(this.playerPrefabContainer.GamePlayerPrefab, pairWithDevice: device);
                var player = playerInput.GetComponent<IGamePlayer>();
                player.SetId(playerInput.user.id);
                player.SetDeviceId(device.deviceId);
                player.SwitchToInput(ActionMapNames.Game);
                player.CreateTank();
                playersToCreate.Add(player);
            }

            return playersToCreate;
        }

        private void OnPauseHandler()
        {
            this.SetPause(this.isPaused = !this.isPaused);
        }

        private void SetPause(bool isPaused)
        {
            this.pauseUi.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;

            foreach (var player in this.players)
            {
                player.SwitchToInput(this.isPaused ? ActionMapNames.Ui : ActionMapNames.Game);
            }
        }
    }
}