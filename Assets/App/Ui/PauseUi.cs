using Tanks.App.Inputs;
using Tanks.App.Scenes;
using UnityEngine;

namespace Tanks.App.Ui
{
    public class PauseUi : MonoBehaviour
    {
        [SerializeField] private UiInputAdapter uiInputAdapter;

        [SerializeField] private RestartGameChannel restartGameChannel;

        [SerializeField] private RestartLevelChannel restartLevelChannel;

        private void OnEnable()
        {
            this.uiInputAdapter.OnSubmit += this.OnSubmitHandler;
            this.uiInputAdapter.OnCancel += this.OnCancelHandler;
        }

        private void OnDisable()
        {
            this.uiInputAdapter.OnSubmit -= this.OnSubmitHandler;
            this.uiInputAdapter.OnCancel -= this.OnCancelHandler;
        }

        private void OnSubmitHandler(uint playerId)
        {
            this.restartLevelChannel.Broadcast();
        }

        private void OnCancelHandler(uint playerId)
        {
            this.restartGameChannel.Broadcast();
        }
    }
}