using System;
using System.Collections.Generic;
using GI.UnityToolkit.Variables;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GI.UnityToolkit.Events
{
    public abstract class GenericGameEvent<T> : DataObject
    {
#if ODIN_INSPECTOR
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
#else
        [Header("Callbacks")]
#endif
        [SerializeField]
        private UnityEvent<T> response = null;

        private readonly List<Action<T>> _actions = new List<Action<T>>();

        [UsedImplicitly]
        public void Raise(T value)
        {
            _actions.ForEach(action => action.Invoke(value));
            response?.Invoke(value);
        }

        public void AddListener(Action<T> action)
        {
            if (action == null) return;
            _actions.Add(action);
        }

        public void RemoveListener(Action<T> action)
        {
            _actions.Remove(action);
        }
    }
}