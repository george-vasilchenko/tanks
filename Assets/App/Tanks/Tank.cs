using Tanks.App.Inputs;
using UnityEngine;

namespace Tanks.App.Tanks
{
    public class Tank : MonoBehaviour, IGameInputReceiver
    {
        [SerializeField] private TankAmmunition tankAmmunition;

        [SerializeField] private TankTower tankTower;

        [SerializeField] private readonly int movementSpeed = 5;

        [SerializeField] private readonly int rotationSpeed = 100;

        private TankOrientationData orientationData;

        private Transform tankTransform;

        private void Awake()
        {
            this.orientationData = new TankOrientationData();
            this.tankTransform = this.transform;
        }

        private void Update()
        {
            this.tankTransform.position += this.tankTransform.forward * (this.orientationData.AccelInput * Time.deltaTime * this.movementSpeed);
            this.tankTransform.Rotate(0, this.orientationData.MoveDirectionInput * Time.deltaTime * this.rotationSpeed, 0);
            this.tankTower.UpdateRotation(new Vector3(0, this.orientationData.AimDirectionInput * Time.deltaTime * this.rotationSpeed, 0));
        }

        public void Fire()
        {
            var weapon = this.tankAmmunition.GetWeapon();
            weapon.Release(this.tankTower.GetDirection());
        }

        public void Move(Vector2 value)
        {
            this.orientationData.AccelInput = value.y;
            this.orientationData.MoveDirectionInput = value.x;
        }

        public void Look(Vector2 value)
        {
            this.orientationData.AimDirectionInput = value.x;
        }
    }
}