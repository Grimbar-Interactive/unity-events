using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace GI.UnityToolkit.Events
{
    /// <summary>
    /// A listener component for a value-less GameEvent.
    /// </summary>
    [AddComponentMenu("Event Listener/Basic Event Listener")]
    public sealed class GameEventListenerBehaviour : MonoBehaviour
    {
        [FormerlySerializedAs("Event")]
        [SerializeField] private GameEvent gameEvent = null;
        
        [FormerlySerializedAs("Response")]
        [SerializeField] private UnityEvent response = null;

        private void OnEnable()
        {
            if (!gameEvent) return;
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (!gameEvent) return;
            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
    
    /// <summary>
    /// A listener component for a generic-valued GameEvent.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GameEventListenerBehaviour<T> : MonoBehaviour
    {
        [FormerlySerializedAs("Event")]
        [SerializeField] protected GameEvent<T> gameEvent = null;
        
        [FormerlySerializedAs("Response")]
        [SerializeField] protected UnityEvent<T> response = null;
        
        private void OnEnable()
        {
            if (!gameEvent) return;
            gameEvent.AddListener(this);
        }

        private void OnDisable()
        {
            if (!gameEvent) return;
            gameEvent.RemoveListener(this);
        }

        public virtual void OnEventRaised(T value)
        {
            response.Invoke(value);
        }
    }
}