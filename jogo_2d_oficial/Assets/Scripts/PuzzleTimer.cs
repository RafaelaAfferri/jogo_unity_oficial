using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PuzzleTimer : MonoBehaviour
{
    [Header("UI")]
    public Button startButton;
    public GameObject puzzlePanel;
    public Button resolverButton;
    public TMP_Text timerText;

    [Header("Settings")]
    public float duration = 10f;

    [Header("Dependencies")]
    public HudVidaController hudVidaController;

    private Coroutine timerRoutine;

    void Awake()
    {
        puzzlePanel.SetActive(false);
        timerText.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartPuzzle);
        resolverButton.onClick.AddListener(OnResolverClicked);
    }

    void StartPuzzle()
    {
        puzzlePanel.SetActive(true);
        timerText.gameObject.SetActive(true);
        if (timerRoutine != null) StopCoroutine(timerRoutine);
        timerRoutine = StartCoroutine(Timer());
    }

    void OnResolverClicked()
    {
        puzzlePanel.SetActive(false);
        timerText.gameObject.SetActive(false);
        if (timerRoutine != null)
        {
            StopCoroutine(timerRoutine);
            timerRoutine = null;
        }
    }

    IEnumerator Timer()
    {
        float t = duration;
        while (t > 0f)
        {
            t -= Time.deltaTime;
            float remaining = Mathf.Max(t, 0f);
            int minutes = (int)remaining / 60;
            int seconds = (int)remaining % 60;
            int milliseconds = (int)((remaining - Mathf.Floor(remaining)) * 1000f);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
            yield return null;
        }
        timerRoutine = null;
        puzzlePanel.SetActive(false);
        timerText.gameObject.SetActive(false);
        hudVidaController.PerderVida();
    }
}