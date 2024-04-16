using System;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private GameStateAbstractProvider _gameStateProvider;
    
    private static int _currentLevelNum;
    
    void Awake()
    {
        _gameStateProvider = new GameStatePlayerPrefsProvider();
        _gameStateProvider.LoadGameState();
        _currentLevelNum = _gameStateProvider.GameState.LevelNum;
        LevelChanger.OnChangeLevelNum += OnChangeLevel;
    }

    private void OnChangeLevel(int value)
    {
        _gameStateProvider.GameState.LevelNum = value;
        _gameStateProvider.SaveGameState();
        _currentLevelNum = value;
    }

    public static int GetLoadedLevelNum()
    {
        return _currentLevelNum;
    }

    private void OnDestroy()
    {
        LevelChanger.OnChangeLevelNum -= OnChangeLevel;
    }
}
