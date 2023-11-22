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

        private readonly List<Action> _actions = new();
        
#if ODIN_INSPECTOR
        [Title("Debugging", TitleAlignment = TitleAlignments.Centered)]
        [Button("Raise Event"), DisableInEditorMode]
#else
        private bool InEditorMode => Application.isEditor && Application.isPlaying == false;
        
        [Button("Raise Event"), DisableIf(nameof(InEditorMode))]
#endif
        [UsedImplicitly]
        public void Raise()
        {
            _actions.ForEach(action => action.Invoke());
            response?.Invoke();
        }

        public void AddListener(Action action)
        {
            if (action == null) return;
            _actions.Add(action);
        }

        public void RemoveListener(Action action)
        {
            _actions.Remove(action);
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

        private readonly List<Action<T>> _actions = new();
        
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