using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Puzzle_Sala1 : MonoBehaviour
{
    public TMP_InputField inputResposta;
    public Button botaoAvancar;
    public TextMeshProUGUI textoFeedback;


    private string respostaCorreta = "1618";
    public GameObject painelPuzzle;

    public void Start(){

    }

    public void Verificar()
    {
        string respostaDoJogador = inputResposta.text.Trim().ToLower();

        if (respostaDoJogador == respostaCorreta.ToLower())
        {
            textoFeedback.text = "Correto!";
            textoFeedback.gameObject.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);
        }
        else if (System.Text.RegularExpressions.Regex.IsMatch(respostaDoJogador, @"[a-zA-Z]"))
        {
            textoFeedback.text = "A resposta não deve conter letras.";
            textoFeedback.gameObject.SetActive(true);
        }
        else{
            textoFeedback.text = "Não parece estar certo...";
            textoFeedback.gameObject.SetActive(true);
        }
    }

    public void Voltar()
    {
        textoFeedback.gameObject.SetActive(false);
        inputResposta.text = "";
        botaoAvancar.gameObject.SetActive(false);
        SceneManager.LoadScene("Esther"); // Volta para a cena inicial

    }

    public void Avancar()
    {
        Debug.Log("Avançar para a próxima parte do jogo!");
        PuzzleProgressManager.Instance.MarkSolved("Puzzle_Sala1");
        SceneManager.LoadScene("Esther"); // Volta para a cena inicial
    }
}
