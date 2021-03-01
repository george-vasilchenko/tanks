using UnityEngine;

namespace Tanks.App.Tanks
{
    [CreateAssetMenu(fileName = "TankPrefabContainer", menuName = "App/Containers/TankPrefabContainer", order = 0)]
    public class TankPrefabContainer : ScriptableObject
    {
        [SerializeField] private GameObject[] tankPrefabs;

        public GameObject GetTankPrefabById(uint id) => this.tankPrefabs[id];
    }
}