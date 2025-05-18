using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PuzzleTimer : MonoBehaviour
{
    [Header("UI")]
    
    public TMP_Text timerText;

    [Header("Settings")]
    public float duration = 10f;

    [Header("Dependencies")]
    public HudVidaController hudVidaController;

    private Coroutine timerRoutine;

    void Awake()
    {
        timerText.gameObject.SetActive(false);
        
        
    }

    public void StartPuzzle()
    {
        timerText.gameObject.SetActive(true);
        if (timerRoutine != null) StopCoroutine(timerRoutine);
        timerRoutine = StartCoroutine(Timer());
    }

    public void OnResolverClicked()
    {
        
        timerText.text = "Acabou o tempo!";
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
        timerText.gameObject.SetActive(false);
        hudVidaController.PerderVida();
        SceneManager.LoadScene("Sala III");
    }
}