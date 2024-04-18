using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField]private Text _winText;
    [SerializeField]private Text _loseText;
    
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;

        gameObject.SetActive(false);
        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(false);
        
        
        CounterDifferences.OnAllDifferencesFind += OnShowWinCanvas;
        TimerMonoBehaviour.OnTimerIsOver += OnShowLoseCanvas;
        LevelChanger.OnStartNewLvl += OnStartNewLvl;
    }

    void OnShowWinCanvas()
    {
        _loseText.gameObject.SetActive(false);
        _winText.gameObject.SetActive(true);
        ShowCanvas();
    }
    
    void OnShowLoseCanvas()
    {
        _winText.gameObject.SetActive(false);
        _loseText.gameObject.SetActive(true);
        ShowCanvas();
    }
    
    private void ShowCanvas()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1;
    }

    private void OnStartNewLvl()
    {
        _canvasGroup.alpha = 0;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        CounterDifferences.OnAllDifferencesFind -= OnShowWinCanvas;
        TimerMonoBehaviour.OnTimerIsOver -= OnShowLoseCanvas;
        LevelChanger.OnStartNewLvl -= OnStartNewLvl;
    }
}
