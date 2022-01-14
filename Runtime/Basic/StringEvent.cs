using UnityEngine;
using UnityEngine.Events;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/String")]
    public class StringEvent : GenericGameEvent<string, UnityStringEvent, StringEvent> {}

    [System.Serializable]
    public class UnityStringEvent : UnityEvent<string> {}
}