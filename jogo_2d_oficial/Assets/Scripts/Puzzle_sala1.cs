using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Puzzle_Sala1 : MonoBehaviour
{
    public TMP_InputField  inputResposta;
    public Button botaoEnviar;

    public Button botaoFechar;

    public Button botaoAvancar;
    public TextMeshProUGUI textoFeedback;

    private string respostaCorreta = "1315"; // Resposta correta para o puzzle

    public GameObject painelPuzzle; // Referência ao painel do puzzle

    public void Voltar()
    {
        painelPuzzle.SetActive(false); // Desativa o painel do puzzle
    }

    public void VerificarResposta()
    {
        string respostaDoJogador = inputResposta.text.Trim().ToLower();

        if (respostaDoJogador == respostaCorreta.ToLower())
        {
            textoFeedback.text = "Correto!";
            textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta correta
            botaoAvancar.gameObject.SetActive(true); // Ativa o botão de avançar
            // Aqui você pode chamar uma função para abrir uma porta, trocar de cena etc.
        }
        else
        {
            textoFeedback.text = "Não parece estar certo...";
            textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta incorreta
        }
    }
    
    public void Avancar(){

        // Aqui você pode adicionar a lógica para avançar no jogo, como abrir uma porta ou trocar de cena
        Debug.Log("Avançar para a próxima parte do jogo!");
    }
}
