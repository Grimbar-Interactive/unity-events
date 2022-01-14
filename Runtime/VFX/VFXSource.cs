using System;
using System.Collections;
using UnityEngine;
using GI.UnityToolkit.Utilities;

namespace GI.UnityToolkit.Events
{
    public class VFXSource : MonoBehaviour
    {
        [SerializeField] private float lifetime = 1f;

        public Action<VFXSource> ReturnAction { private get; set; }

        private Coroutine _coroutine;

        private void OnEnable()
        {
            _coroutine = StartCoroutine(Play());

            IEnumerator Play()
            {
                yield return Wait.Time(lifetime);
                _coroutine = null;
                ReturnAction?.Invoke(this);
            }
        }

        private void OnDisable()
        {
            if (_coroutine == null) return;
            StopCoroutine(_coroutine);
            _coroutine = null;
            ReturnAction = null;
        }
    }
}