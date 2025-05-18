using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Puzzel1_sala3 : MonoBehaviour
{

    public Button botaoAvancar;
    public TextMeshProUGUI textoFeedback;
    public TMP_InputField inputResposta;

    private string respostaCorreta = "75";
    
    private PuzzleSaver puzzle;
    
    public PuzzleTimer timer;

    public void Start()
    {
        puzzle = PuzzleSaver.Instance;
        if (!puzzle.puzzle1_sala3)
        {

            timer.StartPuzzle();
            inputResposta.text = "";
            botaoAvancar.gameObject.SetActive(false);
            textoFeedback.gameObject.SetActive(false);

        }
    }


    public void Verificar(){

        string respostaDoJogador = inputResposta.text.Trim().ToLower();
        if (respostaCorreta == respostaDoJogador)
        {
            textoFeedback.text = "Resposta Correta!";
            textoFeedback.gameObject.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);
            timer.OnResolverClicked();
            // SceneManager.LoadScene("Sala4");
        }
        else if (System.Text.RegularExpressions.Regex.IsMatch(inputResposta.text, @"[a-zA-Z]"))
        {
            textoFeedback.text = "A resposta não deve conter letras.";
            textoFeedback.gameObject.SetActive(true);
        }
        else
        {
            textoFeedback.text = "Não parece estar certo...";
            textoFeedback.gameObject.SetActive(true);
        }
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Sala III"); // Volta para a cena inicia
    }

    public void Avancar()
    {
        puzzle.puzzle1_sala3 = true;
        PuzzleProgressManager.Instance.MarkSolved("Puzzle1_Sala3");
        SceneManager.LoadScene("Sala III"); // Avança para a próxima sala

    }

    



}
