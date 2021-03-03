using UnityEngine;

namespace Tanks.App.Tanks
{
    public class TankCreator : MonoBehaviour
    {
        [SerializeField] private TankSpawnContainer tankSpawnContainer;

        [SerializeField] private TankPrefabContainer tankPrefabContainer;

        public Tank Create(uint tankId)
        {
            var location = this.tankSpawnContainer.GetLocation();
            var prefab = this.tankPrefabContainer.GetTankPrefabById(tankId);

            return Instantiate(prefab, location.position, Quaternion.identity).GetComponent<Tank>();
        }
    }
}