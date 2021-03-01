using UnityEngine;

namespace Tanks.App.Tanks
{
    [CreateAssetMenu(fileName = "TankSpawnContainer", menuName = "App/Containers/TankSpawnContainer", order = 0)]
    public class TankSpawnContainer : ScriptableObject
    {
        [SerializeField] private Transform[] locations;

        public Transform GetLocationAt(int index) => this.locations[index];
    }
}