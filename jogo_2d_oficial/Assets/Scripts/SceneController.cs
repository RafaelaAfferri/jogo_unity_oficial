using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string cena1 = "Esther";  // coloque aqui o nome exato da sua cena

    public void Jogar()
    {
        SceneManager.LoadScene(cena1);
    }
}
