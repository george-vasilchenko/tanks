using Tanks.App.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tanks.App.Inputs
{
    [CreateAssetMenu(fileName = "PlayerJoinedGameChannel", menuName = "App/Channels/PlayerJoinedGameChannel", order = 0)]
    public class PlayerJoinedGameChannel : Channel<PlayerInput>
    {
    }
}