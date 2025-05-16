using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuController : MonoBehaviour
{
    public GameObject MenuCanvas;
    private bool isPaused = false;

    void Start()
    {
        MenuCanvas.SetActive(false);
        Time.timeScale = 1f; // garante que começa despausado
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        MenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        MenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
