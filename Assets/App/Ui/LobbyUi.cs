using System.Linq;
using Tanks.App.Inputs;
using Tanks.App.Lobbies;
using Tanks.App.Players;
using UnityEngine;

namespace Tanks.App.Ui
{
    public class LobbyUi : MonoBehaviour
    {
        [SerializeField] private LobbyReadyChannel lobbyReadyChannel;

        [SerializeField] private UiInputAdapter inputAdapter;

        [SerializeField] private PlayerJoinedLobbyChannel playerJoinedLobbyChannel;

        [SerializeField] private GameObject readyToBeginText;

        [SerializeField] private LobbyUiSlot[] slots;

        private bool isLobbyReady;

        private void Start()
        {
            this.InitializeUiElements();
        }

        private void OnEnable()
        {
            this.inputAdapter.OnSubmit += this.OnSubmitHandler;
            this.inputAdapter.OnCancel += this.OnCancelHandler;
            this.inputAdapter.OnStart += this.OnStartHandler;
            this.playerJoinedLobbyChannel.OnInvoked += this.OnPlayerJoinedLobbyHandler;
        }

        private void OnDisable()
        {
            this.inputAdapter.OnSubmit -= this.OnSubmitHandler;
            this.inputAdapter.OnCancel -= this.OnCancelHandler;
            this.inputAdapter.OnStart -= this.OnStartHandler;
            this.playerJoinedLobbyChannel.OnInvoked -= this.OnPlayerJoinedLobbyHandler;
        }

        private void OnStartHandler(uint playerId)
        {
            if (!this.isLobbyReady)
            {
                return;
            }

            this.lobbyReadyChannel.Broadcast();
        }

        private void OnSubmitHandler(uint playerId)
        {
            this.SetSlotReady(playerId, true);
            this.UpdateLobbyReadiness();
        }

        private void UpdateLobbyReadiness()
        {
            var activeSlotsCount = 0;
            var readySlotsCount = 0;

            foreach (var slot in this.slots)
            {
                if (slot.IsFree)
                {
                    continue;
                }

                activeSlotsCount++;

                if (slot.IsReady)
                {
                    readySlotsCount++;
                }
            }

            var allSlotsReady = activeSlotsCount.Equals(readySlotsCount);
            this.isLobbyReady = allSlotsReady;
            this.readyToBeginText.SetActive(allSlotsReady);
        }

        private void OnCancelHandler(uint playerId)
        {
            this.SetSlotReady(playerId, false);
            this.UpdateLobbyReadiness();
        }

        private void SetSlotReady(uint playerId, bool isReady)
        {
            var slot = this.slots.Single(s => !s.IsFree && s.Profile.Id == playerId);
            slot.SetReady(isReady);
        }

        private void InitializeUiElements()
        {
            foreach (var slot in this.slots)
            {
                slot.Disable();
            }

            this.readyToBeginText.SetActive(false);
        }

        private void OnPlayerJoinedLobbyHandler(IPlayer player)
        {
            foreach (var slot in this.slots)
            {
                if (!slot.IsFree)
                {
                    continue;
                }

                slot.Activate(player);
                break;
            }
        }
    }
}