using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Utilities;

namespace GI.UnityToolkit.Events.Components
{
    public class RandomEventInvoker : MonoBehaviour
    {
        [SerializeField] private List<UnityEvent> events = new List<UnityEvent>();

        public void InvokeRandomEvent()
        {
            if (events.Count == 0) return;
            events.GetRandom().Invoke();
        }
    }
}