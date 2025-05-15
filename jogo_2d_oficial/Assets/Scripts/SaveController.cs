using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private string saveLocation;

    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        // Salvar posição do jogador
        saveData.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        // Salvar cena atual
        saveData.sceneName = SceneManager.GetActiveScene().name;

        // Serializar e salvar no arquivo
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
        Debug.Log("Jogo salvo em: " + saveLocation);
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

            // Carregar posição do jogador
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            // Carregar cena se for diferente
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
