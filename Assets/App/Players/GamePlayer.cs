using Tanks.App.Inputs;
using Tanks.App.Tanks;
using UnityEngine;

namespace Tanks.App.Players
{
    [RequireComponent(typeof(GameInputReader))]
    public class GamePlayer : Player, IGamePlayer
    {
        [SerializeField] private TankCreator tankCreator;
        [SerializeField] private GameInputReader gameInputReader;

        private Tank tank;

        public void Reset()
        {
        }

        public void CreateTank()
        {
            this.tank = this.tankCreator.Create(0);
            this.gameInputReader.SetReceiver(this.tank);
        }
    }
}