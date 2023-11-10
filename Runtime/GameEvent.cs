using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;
using JetBrains.Annotations;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using NaughtyAttributes;
#endif

namespace GI.UnityToolkit.Events
{
    /// <summary>
    /// A game event with no value.
    /// </summary>
    [CreateAssetMenu(menuName = "Event/Basic/Basic (no value)", order = -1)]
    public sealed class GameEvent : DataObject
    {
#if ODIN_INSPECTOR
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
#else
        [Header("Callbacks")]
#endif
        [SerializeField] private UnityEvent response = null;
        
        private readonly List<GameEventListenerBehaviour> _listeners = new();
        
#if ODIN_INSPECTOR
        [Title("Debugging", TitleAlignment = TitleAlignments.Centered)]
        [Button("Raise Event"), DisableInEditorMode]
#else
        private bool InEditorMode => Application.isEditor && Application.isPlaying == false;
        
        [Button("Raise Event"), DisableIf(nameof(InEditorMode))]
#endif
        public void Raise()
        {
            response?.Invoke();
            for (var i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListenerBehaviour listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListenerBehaviour listener)
        {
            _listeners.Remove(listener);
        }
    }
    
    public abstract class GameEvent<T> : DataObject
    {
#if ODIN_INSPECTOR
        [Title("Callbacks", TitleAlignment = TitleAlignments.Centered)]
#else
        [Header("Callbacks")]
#endif
        [SerializeField] private UnityEvent<T> response = null;

        private readonly List<GameEventListenerBehaviour<T>> _listeners = new();

        private readonly List<Action<T>> _actions = new();
        
        [UsedImplicitly]
        public void Raise(T value)
        {
            _listeners.ForEach(listener => listener.OnEventRaised(value));
            _actions.ForEach(action => action.Invoke(value));
            response?.Invoke(value);
        }

        public void AddListener(GameEventListenerBehaviour<T> listener)
        {
            if (listener == null) return;
            _listeners.Add(listener);
        }

        public void AddListener(Action<T> action)
        {
            _actions.Add(action);
        }

        public void RemoveListener(GameEventListenerBehaviour<T> listener)
        {
            _listeners.Remove(listener);
        }

        public void RemoveListener(Action<T> action)
        {
            _actions.Remove(action);
        }
        
#if UNITY_EDITOR
#if ODIN_INSPECTOR
        [Title("Debugging", TitleAlignment = TitleAlignments.Centered)]
        [Button("Raise Event"), DisableInEditorMode]
#else
        private bool InEditorMode => Application.isEditor && Application.isPlaying == false;

        [ShowNonSerializedField]
#endif
        [NonSerialized] protected T debugValue = default;
        
#if ODIN_INSPECTOR
        [Button("Raise Event"), DisableInEditorMode]
#else
        [Button("Raise Event"), DisableIf(nameof(InEditorMode))]
#endif
        [UsedImplicitly]
        private void DebugRaiseEvent() => Raise(debugValue);
#endif
    }
}