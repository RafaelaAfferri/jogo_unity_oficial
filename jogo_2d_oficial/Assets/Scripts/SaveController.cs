using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    
    public GameObject saveFeedbackText;
    private CanvasGroup canvasGroup;

    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        canvasGroup = saveFeedbackText.GetComponent<CanvasGroup>();
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        saveData.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        saveData.sceneName = SceneManager.GetActiveScene().name;

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
        Debug.Log("Jogo salvo em: " + saveLocation);

        if (saveFeedbackText != null)
        {
            StartCoroutine(ShowSaveFeedback());
        }
    }

private IEnumerator ShowSaveFeedback()
{
    saveFeedbackText.SetActive(true);
    canvasGroup.alpha = 0f;

    // Fade In
    float fadeInDuration = 0.5f;
    for (float t = 0; t < fadeInDuration; t += Time.unscaledDeltaTime)
    {
        canvasGroup.alpha = t / fadeInDuration;
        yield return null;
    }
    canvasGroup.alpha = 1f;

    // Espera visível
    yield return new WaitForSecondsRealtime(1.5f);

    // Fade Out
    float fadeOutDuration = 0.5f;
    for (float t = 0; t < fadeOutDuration; t += Time.unscaledDeltaTime)
    {
        canvasGroup.alpha = 1f - (t / fadeOutDuration);
        yield return null;
    }
    canvasGroup.alpha = 0f;

    saveFeedbackText.SetActive(false);
}


    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            if (SceneManager.GetActiveScene().name != saveData.sceneName)
            {
                SceneManager.LoadScene(saveData.sceneName);
            }

            Debug.Log("Jogo carregado da cena: " + saveData.sceneName);
        }
        else
        {
            Debug.Log("Nenhum save encontrado.");
        }
    }
}
