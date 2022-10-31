using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/GameEvent")]
    public class GameEvent : DataObject
    {
#if ODIN_INSPECTOR
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
#else
        [Header("Callbacks")]
#endif
        [SerializeField] private UnityEvent response = null;
        
        private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();
        
#if ODIN_INSPECTOR
        [Button("Raise Event"), DisableInEditorMode]
#else
        [Button("Raise Event")]
#endif
        public void Raise()
        {
            response?.Invoke();
            for (var i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}