using UnityEngine;

public class Divisor : MonoBehaviour, IInteractable
{
    private int _minValue = 2;
    private int _maxValue = 5;
    private float _scale = 0.5f;

    public void Execute()
    {
        InitializeDivided();
    }

    private void InitializeDivided()
    {
        int count = Random.Range(_minValue, _maxValue);

        GameObject scaledObject = gameObject;
        scaledObject.transform.localScale *= _scale;

        for (int i = 0; i < count; i++)
        {
            scaledObject = Instantiate(scaledObject);
            scaledObject.transform.SetParent(transform.parent);
        }
    }
}
