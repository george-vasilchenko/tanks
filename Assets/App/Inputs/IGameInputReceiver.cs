using UnityEngine;

namespace Tanks.App.Inputs
{
    public interface IGameInputReceiver
    {
        void Move(Vector2 value);

        void Look(Vector2 value);

        void Fire();
    }
}