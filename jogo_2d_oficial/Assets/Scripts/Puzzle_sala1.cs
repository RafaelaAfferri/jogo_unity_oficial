using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puzzle_Sala1 : MonoBehaviour
{
    public TMP_InputField inputResposta;
    public Button botaoAvancar;
    public TextMeshProUGUI textoFeedback;

    private string respostaCorreta = "1315";
    public GameObject painelPuzzle;

    public void Verificar()
    {
        string respostaDoJogador = inputResposta.text.Trim().ToLower();

        if (respostaDoJogador == respostaCorreta.ToLower())
        {
            textoFeedback.text = "Correto!";
            textoFeedback.gameObject.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);
        }
        else
        {
            textoFeedback.text = "Não parece estar certo...";
            textoFeedback.gameObject.SetActive(true);
        }
    }

    public void Voltar()
    {
        painelPuzzle.SetActive(false);
        textoFeedback.gameObject.SetActive(false);
        inputResposta.text = "";
        botaoAvancar.gameObject.SetActive(false);
    }

    public void Avancar()
    {
        painelPuzzle.SetActive(false);
        Debug.Log("Avançar para a próxima parte do jogo!");
    }
}
