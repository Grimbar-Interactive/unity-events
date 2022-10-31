using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Listener")]
    public class GameEventListenerDataObject : DataObject, IGameEventListener
    {
        [SerializeField] private GameEvent Event = null;
        [SerializeField] private UnityEvent Response = null;

        protected override void OnBegin()
        {
            if (!Event) return;
            Event.RegisterListener(this);
        }

        protected override void OnEnd()
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