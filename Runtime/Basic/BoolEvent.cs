using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Bool")]
    public class BoolEvent : GenericGameEvent<bool, UnityBoolEvent, BoolEvent> {}

    [System.Serializable]
    public class UnityBoolEvent : UnityEvent<bool> {}
}