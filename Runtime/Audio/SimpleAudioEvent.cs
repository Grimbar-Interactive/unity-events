using UnityEngine;
using GI.UnityToolkit.Variables;

namespace GI.UnityToolkit.Events.Audio
{
    [CreateAssetMenu(menuName = "Event/Audio/Simple")]
    public class SimpleAudioEvent : AudioEvent
    {
        public AudioClip[] Clips;
        public RangedFloat volume;
        [MinMaxFloatRange(0, 2)] public RangedFloat pitch;
        
        public override void Play(AudioSource source)
        {
            if (Clips == null || Clips.Length == 0) return;
            
            source.clip = Clips[Random.Range(0, Clips.Length)];
            source.volume = Random.Range(volume.Min, volume.Max);
            source.pitch = Random.Range(pitch.Min, pitch.Max);
            source.Play();
        }
    }
}