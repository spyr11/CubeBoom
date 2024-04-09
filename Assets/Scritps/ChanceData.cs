using UnityEngine;

public class ChanceData : MonoBehaviour
{
    private int _count = 1;
    private int _multiplier = 2;

    public int Count => _count;

    public void Increase()
    {
        _count *= _multiplier;
    }
}
