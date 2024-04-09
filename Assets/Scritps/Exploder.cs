using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour, IInteractable
{
    [SerializeField] private ParticleSystem _particleSystem;
    private float _radius = 10f;
    private float _force = 500f;

    public void Execute()
    {
        BlowUp();
    }

    private void BlowUp()
    {
        foreach (var item in GetObjects())
        {
            item.AddExplosionForce(_force, transform.position, _radius);
        }

        _particleSystem = Instantiate(_particleSystem, transform.position, transform.rotation);
    }

    private List<Rigidbody> GetObjects()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> hits = new List<Rigidbody>();

        foreach (Collider hit in colliders)
        {
            if (hit.attachedRigidbody != null)
            {
                hits.Add(hit.attachedRigidbody);
            }
        }

        return hits;
    }
}
