using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Bool")]
    public class BoolEvent : GameEvent<bool>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
#if !ODIN_INSPECTOR
            debugValue = true;
#endif
        }
#endif
    }
}