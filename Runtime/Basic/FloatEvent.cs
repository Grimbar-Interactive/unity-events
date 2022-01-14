using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Float")]
    public class FloatEvent : GenericGameEvent<bool, UnityFloatEvent, FloatEvent> {}

    [System.Serializable]
    public class UnityFloatEvent : UnityEvent<bool> {}
}