using Sirenix.OdinInspector;
using UnityEngine;

namespace GI.UnityToolkit.Events
{
    [CreateAssetMenu(menuName = "Event/VFX/Text")]
    public class TextEffectEvent : VFXEventBase<TextEffectSource>
    {
        public TextEffectSource PlayText(string text, Color color, Vector3 position = default,
            Transform transform = null)
        {
            var vfx = SpawnVFX(position, transform);
            vfx.SetText(text, color);
            return vfx;
        }

        public TextEffectSource PlayText(string text, Color topColor, Color bottomColor, Vector3 position = default,
            Transform transform = null)
        {
            var vfx = SpawnVFX(position, transform);
            vfx.SetText(text, topColor, bottomColor);
            return vfx;
        }
        
#if UNITY_EDITOR
        [DisableInEditorMode, Button("Test"), PropertySpace(10)]
        private void Test() => PlayText("Test!", Color.white);
#endif
    }
}