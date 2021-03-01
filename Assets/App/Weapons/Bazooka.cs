using UnityEngine;

namespace Tanks.App.Weapons
{
    public class Bazooka : TankWeapon
    {
        [SerializeField] private Transform spawnLocation;

        [SerializeField] private BulletPrefabContainer bulletPrefabContainer;

        [SerializeField] private readonly int force = 30;

        [SerializeField] private readonly float releaseDelay = 1;

        private float releaseCounter;

        private bool releaseIsReady;

        private void Update()
        {
            this.UpdateReleaseCounter();
        }

        public override void Release(Vector3 direction)
        {
            if (!this.releaseIsReady)
            {
                return;
            }

            var prefab = this.bulletPrefabContainer.BazookaBulletPrefab;
            var instance = Instantiate(
                prefab,
                this.spawnLocation.position,
                Quaternion.Euler(direction));
            Destroy(instance, 3);

            var rb = instance.AddComponent<Rigidbody>();
            rb.AddForce(direction * this.force, ForceMode.Impulse);

            this.ResetReleaseCounter();
        }

        private void UpdateReleaseCounter()
        {
            if (!this.releaseIsReady)
            {
                this.releaseCounter -= Time.deltaTime;
                this.releaseIsReady = this.releaseCounter <= 0;
            }
        }

        private void ResetReleaseCounter()
        {
            this.releaseIsReady = false;
            this.releaseCounter = this.releaseDelay;
        }
    }
}