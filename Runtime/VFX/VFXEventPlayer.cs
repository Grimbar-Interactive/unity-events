using Sirenix.OdinInspector;
using UnityEngine;

namespace GI.UnityToolkit.Events
{
    public class VFXEventPlayer : MonoBehaviour
    {
        [Title("Event")] [SerializeField] private VFXEvent vfxEvent = default;

        [Title("Settings")] [SerializeField] private Vector3 offset = default;
        [SerializeField] private bool setAsVFXParent = false;

        public void Play()
        {
            vfxEvent.Play(setAsVFXParent ? offset : transform.position + offset, setAsVFXParent ? transform : null);
        }
    }
}