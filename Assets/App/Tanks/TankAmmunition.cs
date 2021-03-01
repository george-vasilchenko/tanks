using System;
using Tanks.App.Weapons;
using UnityEngine;

namespace Tanks.App.Tanks
{
    public class TankAmmunition : MonoBehaviour
    {
        [SerializeField] private TankWeapon[] weapons;

        private int currentWeaponIndex;

        private void Start()
        {
            this.currentWeaponIndex = 0;
        }

        public TankWeapon GetWeapon() => this.weapons[this.currentWeaponIndex];

        public void Switch()
        {
            throw new NotImplementedException();
        }
    }
}