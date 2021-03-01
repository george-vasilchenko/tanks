using UnityEngine;

namespace TankArcade.App.Features.Weapons
{
    [CreateAssetMenu(fileName = "BulletPrefabContainer", menuName = "App/Containers/BulletPrefabContainer", order = 0)]
    public class BulletPrefabContainer : ScriptableObject
    {
        [SerializeField] private GameObject bazookaBulletPrefab;

        public GameObject BazookaBulletPrefab => this.bazookaBulletPrefab;
    }
}