using UnityEngine;

namespace Tanks.App.Tanks
{
    public class TankCreator : MonoBehaviour
    {
        [SerializeField] private TankSpawnContainer tankSpawnContainer;

        [SerializeField] private TankPrefabContainer tankPrefabContainer;

        public Tank Create(uint tankId, uint playerId)
        {
            var location = this.tankSpawnContainer.GetLocationAt((int)playerId);
            var prefab = this.tankPrefabContainer.GetTankPrefabById(tankId);

            return Instantiate(prefab, location.position, Quaternion.identity).GetComponent<Tank>();
        }
    }
}