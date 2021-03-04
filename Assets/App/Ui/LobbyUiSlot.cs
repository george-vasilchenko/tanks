using Tanks.App.Players;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.App.Ui
{
    public class LobbyUiSlot : MonoBehaviour
    {
        [SerializeField] private Color slotColor;

        [SerializeField] private Image slotImage;

        [SerializeField] private Image readyImage;

        public bool IsReady { get; private set; }

        public IPlayer Player { get; private set; }

        public bool IsFree => this.Player == null;

        private void Awake()
        {
            this.slotImage.color = this.slotColor;
        }

        public void Activate(IPlayer player)
        {
            this.Player = player;
            this.gameObject.SetActive(true);
        }

        public void Disable()
        {
            this.Player = null;
            this.UpdateReadyStatus(false);
            this.gameObject.SetActive(false);
        }

        private void UpdateReadyStatus(bool isReady)
        {
            this.IsReady = isReady;
            this.readyImage.color = isReady ? Color.green : Color.red;
        }

        public void SetReady(bool isReady)
        {
            this.UpdateReadyStatus(isReady);
        }
    }
}