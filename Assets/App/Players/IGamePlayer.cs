namespace Tanks.App.Players
{
    public interface IGamePlayer : IPlayer
    {
        void CreateTank();

        void Reset();
    }
}