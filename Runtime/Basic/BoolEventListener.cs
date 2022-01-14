using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    public class BoolEventListener : GenericGameEventListener<bool, UnityBoolEvent, BoolEvent>
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