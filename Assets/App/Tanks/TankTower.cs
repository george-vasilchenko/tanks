using UnityEngine;

namespace Tanks.App.Tanks
{
    public class TankTower : MonoBehaviour
    {
        private Transform towerTransform;

        private void Awake()
        {
            this.towerTransform = this.transform;
        }

        public Vector3 GetDirection() => this.towerTransform.forward;

        public void UpdateRotation(Vector3 rotation)
        {
            this.towerTransform.Rotate(rotation);
        }
    }
}