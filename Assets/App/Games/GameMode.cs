using System;
using System.Collections.Generic;
using Tanks.App.Globals;
using Tanks.App.Inputs;
using Tanks.App.Lobbies;
using Tanks.App.Players;
using Tanks.App.Scenes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Tanks.App.Games
{
    public class GameMode : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private ScenePersistenceHandler scenePersistenceHandler;
        [SerializeField] private GameInputAdapter gameInputAdapter;
        [SerializeField] private GameObject pauseUi;
        private bool isPaused;
        private IEnumerable<IPlayer> players;

        private void Start()
        {
            this.players = this.CreatePlayers();
            this.SetPause(false);
        }

        private IEnumerable<IPlayer> CreatePlayers()
        {
            var playersToCreate = new List<IPlayer>();
            foreach (var playerDevice in this.scenePersistenceHandler.PlayersDevices)
            {
                var device = InputSystem.GetDeviceById(playerDevice.Value);
                var playerInput = PlayerInput.Instantiate(this.playerPrefab, pairWithDevice: device);
                var player = playerInput.GetComponent<IPlayer>();
                player.SetId(playerInput.user.id);
                player.SetDeviceId(device.deviceId);
                player.SwitchToInput(ActionMapNames.Game);
                player.CreateTank();
                playersToCreate.Add(player);
            }
            return playersToCreate;
        }

        private void OnEnable()
        {
            this.gameInputAdapter.OnPause += this.OnPauseHandler;
        }
        
        private void OnDisable()
        {
            this.gameInputAdapter.OnPause -= this.OnPauseHandler;
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