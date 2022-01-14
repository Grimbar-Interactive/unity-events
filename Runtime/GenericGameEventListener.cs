using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    public abstract class GenericGameEventListener<T, TUnityEvent, TGenericGameEvent> : MonoBehaviour 
        where TUnityEvent : UnityEvent<T>
        where TGenericGameEvent : GenericGameEvent<T, TUnityEvent, TGenericGameEvent>
    {
        public TGenericGameEvent Event = null;
        public TUnityEvent Response = null;
        
        private void OnEnable()
        {
            if (!Event) return;
            Event.AddListener(this);
        }

        private void OnDisable()
        {
            if (!Event) return;
            Event.RemoveListener(this);
        }

        public virtual void OnEventRaised(T value)
        {
            Response.Invoke(value);
        }
    }
}