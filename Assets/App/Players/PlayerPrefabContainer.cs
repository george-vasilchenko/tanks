using UnityEngine;

namespace Tanks.App.Players
{
    [CreateAssetMenu(fileName = "PlayerPrefabContainer", menuName = "App/Containers/PlayerPrefabContainer", order = 0)]
    public class PlayerPrefabContainer : ScriptableObject
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject gamePlayerPrefab;

        public GameObject PlayerPrefab => this.playerPrefab;

        public GameObject GamePlayerPrefab => this.gamePlayerPrefab;
    }
}