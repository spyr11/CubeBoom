using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Divisor))]
[RequireComponent(typeof(Exploder))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Divisor _divisor;
    [SerializeField] private Exploder _exploder;

    private List<IInteractable> _interactObjects;
    private ChanceData _chanceData;

    private void Start()
    {
        _divisor = GetComponent<Divisor>();
        _exploder = GetComponent<Exploder>();

        _interactObjects = new List<IInteractable>() { _divisor, _exploder };

        if ((_chanceData = GetComponentInParent<ChanceData>()) == false)
        {
            throw new NullReferenceException();
        }
    }

    void OnMouseDown()
    {
        int index = 0;

        if (UnityEngine.Random.Range(0, _chanceData.Count) > 0)
        {
            index++;
        }

        _chanceData.Increase();

        _interactObjects[index].Execute();

        Destroy(gameObject);
    }
}
