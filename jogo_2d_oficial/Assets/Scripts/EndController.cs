using UnityEngine;
using UnityEngine.SceneManagement;


public class EndController : MonoBehaviour
{

    private HudVidaController hudController;
    private PuzzleSaver puzzle;

    private void Awake()
    {
        puzzle = PuzzleSaver.Instance;
        hudController = FindFirstObjectByType<HudVidaController>();
        if (hudController == null)
        {
            Debug.LogError("HudVidaController não encontrado na cena.");
        }

    }

    public void Final()
    {
        
        if (puzzle.puzzle1_salaSecreta)
        {
            SceneManager.LoadScene("Final Bom");
        }
        else if (hudController.vidasAtuais <= 2)
        {
            SceneManager.LoadScene("Final Ruim");
        }
        else
        {
            SceneManager.LoadScene("Final Neutro");
        }
    }
    


}