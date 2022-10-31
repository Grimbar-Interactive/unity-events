using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace GI.UnityToolkit.Events
{
    public class VFXEventPlayer : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [Title("Event")] 
#else
        [Header("Event")]
#endif
        [SerializeField] private VFXEvent vfxEvent = default;
        
#if ODIN_INSPECTOR
        [Title("Settings")]
#else
        [Header("Settings")]
#endif
        [SerializeField] private Vector3 offset = default;
        [SerializeField] private bool setAsVFXParent = false;

        public void Play()
        {
            vfxEvent.Play(setAsVFXParent ? offset : transform.position + offset, setAsVFXParent ? transform : null);
        }
    }
}