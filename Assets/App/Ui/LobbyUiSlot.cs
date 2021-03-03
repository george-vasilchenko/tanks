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

        public IPlayer Profile { get; private set; }

        public bool IsFree => this.Profile == null;

        private void Awake()
        {
            this.slotImage.color = this.slotColor;
        }

        public void Activate(IPlayer player)
        {
            this.Profile = player;
            this.gameObject.SetActive(true);
        }

        public void Disable()
        {
            this.Profile = null;
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