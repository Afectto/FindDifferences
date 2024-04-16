using System;
using UnityEngine;

public class FindDifferences : MonoBehaviour
{
    private bool _differenceFound = false;

    public static Action<GameObject> OnDifferenceFound;
    
    public void OnClickDifference()
    {
        if (!_differenceFound)
        {
            _differenceFound = true;
            OnDifferenceFound?.Invoke(gameObject);
        }
    }

    public void SetDifferenceFound(bool value)
    {
        _differenceFound = value;
    }
    
    public bool IsDifferenceFound()
    {
        return _differenceFound;
    }
    
}
