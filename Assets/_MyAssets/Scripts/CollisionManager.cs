using System;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static event EventHandler<OnCollisionOccuredEventArgs> OnCollisionOccured;

    public class OnCollisionOccuredEventArgs: EventArgs
    {
        public int CollisionValue;
    }
    [SerializeField] private Material _hitMaterial = default(Material);
    [SerializeField] private int _collisionValue = 1;

    private bool _estToucher = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!_estToucher && collision.gameObject.CompareTag("Player"))
        {
            if(TryGetComponent<MeshRenderer>(out MeshRenderer meshRenderer)) 
            {
                meshRenderer.material = _hitMaterial;
            }
            else
            {
                MeshRenderer[] mesh = GetComponentsInChildren<MeshRenderer>();
                foreach(var m in mesh)
                {
                    m.material = _hitMaterial;
                }
            }
            // le ? regarde si il y as qqn qui écoute, si oui, il déclenche l'event. sinon, il ne le declenche pas
            OnCollisionOccured?.Invoke(this, new OnCollisionOccuredEventArgs
            {
                CollisionValue = _collisionValue
            });
            _estToucher = true;
        }

    }
}
