namespace Tanks.App.Players
{
    public interface IPlayer
    {
        uint Id { get; }

        int DeviceId { get; }

        void SetDeviceId(int deviceId);

        void SetId(uint id);

        void SwitchToInput(string actionMapName);
    }
}