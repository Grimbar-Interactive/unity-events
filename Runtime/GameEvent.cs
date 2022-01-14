using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/GameEvent")]
    public class GameEvent : DataObject
    {
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
        [SerializeField] private UnityEvent response = null;
        
        private readonly List<IGameEventListener> _listeners = new List<IGameEventListener>();
        
        [Button("Raise Event"), DisableInEditorMode]
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