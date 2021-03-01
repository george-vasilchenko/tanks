using System.Collections.Generic;
using Tanks.App.Framework;
using Tanks.App.Players;
using UnityEngine;

namespace Tanks.App.Lobbies
{
    [CreateAssetMenu(fileName = "LobbyContentResponseChannel", menuName = "App/Channels/LobbyContentResponseChannel", order = 0)]
    public class LobbyContentResponseChannel : Channel<IEnumerable<IPlayer>>
    {
    }
}