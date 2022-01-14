using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent Event = null;
        public UnityEvent Response = null;

        private void OnEnable()
        {
            if (!Event) return;
            Event.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (!Event) return;
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}