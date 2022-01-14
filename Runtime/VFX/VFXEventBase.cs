using System;
using UnityEngine;
using GI.UnityToolkit.Variables;
using GI.UnityToolkit.Utilities;

namespace GI.UnityToolkit.Events
{
    public abstract class VFXEventBase<T> : DataObject where T : VFXSource
    {
        [SerializeField] private T sourcePrefab = null;
        
        [NonSerialized] private GameObjectPool<T> _pool = null;

        protected override void OnBegin()
        {
            _pool = null;
        }

        protected T SpawnVFX(Vector3 position = default, Transform transform = null)
        {
            if (_pool == null)
            {
                var parent = new GameObject
                {
                    name = $"VFX Pool ({sourcePrefab.name})"
                };
                _pool = new GameObjectPool<T>(sourcePrefab.gameObject, parent.transform);
            }

            var vfx = _pool.Get(transform);
            vfx.transform.localPosition = position;
            vfx.ReturnAction = ReturnVFX;
            return vfx;
        }

        private void ReturnVFX(VFXSource source)
        {
            _pool.Put((T)source);
        }
    }
}