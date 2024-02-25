using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using GI.UnityToolkit.Attributes;
#endif

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/VFX/Simple")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class VFXEvent : VFXEventBase<VFXSource>
    {
        public virtual VFXSource Play(Vector3 position = default, Transform transform = null)
        {
            return SpawnVFX(position, transform);
        }

#if UNITY_EDITOR
#if ODIN_INSPECTOR
        [DisableInEditorMode, Button("Test"), PropertySpace(10)]
#else
        [Button("Test")]
#endif
        private void Test() => Play();
#endif
    }
}