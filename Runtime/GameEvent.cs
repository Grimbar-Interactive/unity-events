using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using GI.UnityToolkit.Variables;
using JetBrains.Annotations;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using GI.UnityToolkit.Attributes;
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

        private readonly List<Action> _actions = new List<Action>();
        
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
}