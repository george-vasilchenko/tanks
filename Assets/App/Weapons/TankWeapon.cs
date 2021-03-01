using UnityEngine;

namespace TankArcade.App.Features.Weapons
{
    public abstract class TankWeapon : MonoBehaviour
    {
        public abstract void Release(Vector3 direction);
    }
}