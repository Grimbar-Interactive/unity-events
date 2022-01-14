using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    public class UnityLifetimeEvents : MonoBehaviour
    {
        [SerializeField] private UnityEvent onAwake = null;
        [SerializeField] private UnityEvent onStart = null;
        [SerializeField] private UnityEvent onEnable = null;
        [SerializeField] private UnityEvent onDisable = null;

        private void Awake() => onAwake?.Invoke();
        private void Start() => onStart?.Invoke();
        private void OnEnable() => onEnable?.Invoke();
        private void OnDisable() => onDisable?.Invoke();
    }
}