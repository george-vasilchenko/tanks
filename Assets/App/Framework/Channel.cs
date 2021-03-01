using System;
using UnityEngine;

namespace Tanks.App.Framework
{
    public abstract class Channel : ScriptableObject
    {
        public event Action OnInvoked;

        public void Broadcast() => this.OnInvoked?.Invoke();
    }

    public abstract class Channel<TArgs> : ScriptableObject
    {
        public event Action<TArgs> OnInvoked;

        public void Broadcast(TArgs args) => this.OnInvoked?.Invoke(args);
    }
}