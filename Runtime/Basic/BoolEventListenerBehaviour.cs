using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    [AddComponentMenu("Event Listener/Bool Event Listener")]
    public class BoolEventListenerBehaviour : GameEventListenerBehaviour<bool>
    {
        [SerializeField] private UnityEvent onInvokedTrue = null;
        [SerializeField] private UnityEvent onInvokedFalse = null;
        
        public override void OnEventRaised(bool value)
        {
            base.OnEventRaised(value);

            if (value)
            {
                onInvokedTrue.Invoke();
            }
            else
            {
                onInvokedFalse.Invoke();
            }
        }
    }
}