using UnityEngine;

namespace Tanks.App.Framework
{
    public class GameContext : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}