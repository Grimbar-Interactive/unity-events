using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Int")]
    public class IntEvent : GameEvent<int>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
#if !ODIN_INSPECTOR
            debugValue = 42;
#endif
        }
#endif
    }
}