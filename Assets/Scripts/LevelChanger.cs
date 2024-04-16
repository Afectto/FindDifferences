using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Text textLvlNum;
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject[] levelPrefab;
    
    private int _currentLvlNum = 1;
    private GameObject _currentLevel;

    public static Action OnStartNewLvl;
    public static Action<int> OnChangeLevelNum;
    
    private void Start()
    {
        _currentLvlNum = SaveLoad.GetLoadedLevelNum();
        textLvlNum.text = "Level " + _currentLvlNum;
        TimerMonoBehaviour.OnTimerIsOver += PrepareRestartCurrentLvl;
        CounterDifferences.OnAllDifferencesFind += PrepareStartNextLvl;
        CreateLevel(0);
    }

    private void PrepareStartNextLvl()
    {
        Destroy(_currentLevel);
        _currentLvlNum++;
        textLvlNum.text = "Level " + _currentLvlNum;
        OnChangeLevelNum?.Invoke(_currentLvlNum);
    }

    private void PrepareRestartCurrentLvl()
    {
        Destroy(_currentLevel);
    }

    public void OnStartNewLevel()
    {
        // if (_currentLvlNum - 1 >= levelPrefab.Length) _currentLvlNum = 1;
        CreateLevel(0);//TODO: Change on add more lvl
        OnStartNewLvl?.Invoke();
    }
    
    private void CreateLevel(int value)
    {
        _currentLevel = Instantiate(levelPrefab[value], canvas.transform);
    }

    private void OnDestroy()
    {
        TimerMonoBehaviour.OnTimerIsOver -= PrepareRestartCurrentLvl;
        CounterDifferences.OnAllDifferencesFind -= PrepareStartNextLvl;
    }
}
