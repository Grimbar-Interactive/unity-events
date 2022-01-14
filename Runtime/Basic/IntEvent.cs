using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Int")]
    public class IntEvent : GenericGameEvent<bool, UnityIntEvent, IntEvent> {}

    [System.Serializable]
    public class UnityIntEvent : UnityEvent<bool> {}
}