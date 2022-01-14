using System;

namespace GI.UnityToolkit.Events
{
    public class GameEventAction : IGameEventListener
    {
        private readonly Action _callback;
        
        public GameEventAction(Action callback)
        {
            _callback = callback;
        }
        
        public void OnEventRaised()
        {
            _callback?.Invoke();
        }
    }
}