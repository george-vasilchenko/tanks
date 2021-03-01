using UnityEngine;

namespace Tanks.App.Weapons
{
    public abstract class TankWeapon : MonoBehaviour
    {
        public abstract void Release(Vector3 direction);
    }
}