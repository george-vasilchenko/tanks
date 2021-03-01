using Tanks.App.Framework;
using Tanks.App.Players;
using UnityEngine;

namespace Tanks.App.Lobbies
{
    [CreateAssetMenu(fileName = "PlayerJoinedLobbyChannel", menuName = "App/Channels/PlayerJoinedLobbyChannel", order = 0)]
    public class PlayerJoinedLobbyChannel : Channel<IPlayer>
    {
    }
}