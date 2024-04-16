using System;
using UnityEngine;
using UnityEngine.UI;

public class CounterDifferences : MonoBehaviour
{
    private Text _text;
    private int _count;

    public static Action OnAllDifferencesFind;
    void Start()
    {
        _text = GetComponent<Text>();
        _count = 0;
        FindDifferences.OnDifferenceFound += OnDifferenceFound;
        LevelChanger.OnStartNewLvl += OnStartNewLvl;
    }

    private void OnStartNewLvl()
    {
        _count = 0;
        _text.text = _count + "/10";
    }

    private void OnDifferenceFound(GameObject obj)
    {
        _count++;
        _text.text = _count + "/10";
        if (_count == 10)
        {
            OnAllDifferencesFind?.Invoke();
        }
    }

    private void OnDestroy()
    {
        FindDifferences.OnDifferenceFound -= OnDifferenceFound;
        LevelChanger.OnStartNewLvl -= OnStartNewLvl;
    }
}
