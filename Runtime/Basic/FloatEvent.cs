using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/Basic/Float")]
    public class FloatEvent : GameEvent<float>
    {
#if UNITY_EDITOR
        private void OnValidate()
        {
#if !ODIN_INSPECTOR
            debugValue = 0.31415f;
#endif
        }
#endif
    }
}