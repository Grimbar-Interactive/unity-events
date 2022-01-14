using Sirenix.OdinInspector;
using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/VFX/Simple")]
    public class VFXEvent : VFXEventBase<VFXSource>
    {
        public virtual VFXSource Play(Vector3 position = default, Transform transform = null)
        {
            return SpawnVFX(position, transform);
        }

#if UNITY_EDITOR
        [DisableInEditorMode, Button("Test"), PropertySpace(10)]
        private void Test() => Play();
#endif
    }
}