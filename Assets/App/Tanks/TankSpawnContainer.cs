using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.App.Tanks
{
    [CreateAssetMenu(fileName = "TankSpawnContainer", menuName = "App/Containers/TankSpawnContainer", order = 0)]
    public class TankSpawnContainer : ScriptableObject
    {
        [SerializeField] private Transform[] locations;
        private int consumptionCounter;

        private void OnEnable()
        {
            SceneManager.activeSceneChanged += this.OnActiveSceneChangedHandler;
        }

        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= this.OnActiveSceneChangedHandler;
        }

        public Transform GetLocation() => this.locations[this.consumptionCounter++];

        private void OnActiveSceneChangedHandler(Scene from, Scene to)
        {
            this.consumptionCounter = 0;
        }
    }
}