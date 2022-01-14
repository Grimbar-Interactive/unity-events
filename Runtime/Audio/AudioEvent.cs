using UnityEngine;
using GI.UnityToolkit.Variables;

namespace GI.UnityToolkit.Events
{
    public abstract class AudioEvent : DataObject
    {
        public abstract void Play(AudioSource source);
    }
}