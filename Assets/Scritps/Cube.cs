using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private int _chanceCount = 1;
    private int _chanceDivisor = 2;
    private int _minCreateValue = 2;
    private int _maxCreateValue = 5;

    private float _newScale = 0.5f;
    private float _explodeRadius = 10f;
    private float _explodeForce = 300f;

    private void OnMouseDown()
    {
        if (Random.Range(0, _chanceCount) == 0)
        {
            BlowUp(GetExplodableObjects());
        }

        Destroy(gameObject);
    }

    private void BlowUp(List<Rigidbody> explodableObjects)
    {
        foreach (var explodableObject in explodableObjects)
        {
            explodableObject.AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        int count = Random.Range(_minCreateValue, _maxCreateValue);

        for (int i = 0; i < count; i++)
        {
            explodableObjects.Add(InitializeScaledObject().GetComponent<Rigidbody>());
        }

        return explodableObjects;
    }

    private Cube InitializeScaledObject()
    {
        Cube scaledObject = Instantiate(this);

        scaledObject.transform.localScale *= _newScale;
        scaledObject.DecreaseChance(_chanceCount);

        return scaledObject;
    }

    private void DecreaseChance(int chanceCount)
    {
        _chanceCount = chanceCount * _chanceDivisor;
    }
}
