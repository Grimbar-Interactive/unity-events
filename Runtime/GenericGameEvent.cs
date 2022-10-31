using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GI.UnityToolkit.Events
{
    public abstract class GenericGameEvent<T, TUnityEvent, TGenericGameEvent> : DataObject
        where TUnityEvent : UnityEvent<T>
        where TGenericGameEvent : GenericGameEvent<T, TUnityEvent, TGenericGameEvent>
    {
#if ODIN_INSPECTOR
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
#else
        [Header("Callbacks")]
#endif
        [SerializeField] private TUnityEvent response = null;

        private readonly List<GenericGameEventListener<T, TUnityEvent, TGenericGameEvent>> _listeners =
            new List<GenericGameEventListener<T, TUnityEvent, TGenericGameEvent>>();

        private readonly List<Action<T>> _actions = new List<Action<T>>();
        
        public void Raise(T value)
        {
            _listeners.ForEach(listener => listener.OnEventRaised(value));
            _actions.ForEach(action => action.Invoke(value));
            response?.Invoke(value);
        }

        public void AddListener(GenericGameEventListener<T, TUnityEvent, TGenericGameEvent> listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void AddListener(Action<T> action)
        {
            _actions.Add(action);
        }

        public void RemoveListener(GenericGameEventListener<T, TUnityEvent, TGenericGameEvent> listener)
        {
            _listeners.Remove(listener);
        }

        public void RemoveListener(Action<T> action)
        {
            _actions.Remove(action);
        }
    }
}