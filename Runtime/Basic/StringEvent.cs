using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/String")]
    public class StringEvent : GameEvent<string>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
            debugValue ??= "Test";
        }
#endif
    }
}