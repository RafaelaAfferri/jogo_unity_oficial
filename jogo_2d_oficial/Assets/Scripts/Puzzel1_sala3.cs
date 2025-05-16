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

    public void Start()
    {   
        inputResposta.text = "";
        botaoAvancar.gameObject.SetActive(false);
        textoFeedback.gameObject.SetActive(false);
    }


    public void Verificar(){

        string respostaDoJogador = inputResposta.text.Trim().ToLower();
        if (respostaCorreta == respostaDoJogador){
            textoFeedback.text = "Resposta Correta!";
            textoFeedback.gameObject.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);
            // SceneManager.LoadScene("Sala4");
        }
        else if (System.Text.RegularExpressions.Regex.IsMatch(inputResposta.text, @"[a-zA-Z]"))
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
        
        // SceneManager.LoadScene("Esther"); // Volta para a cena inicial
    }

    public void Avancar()
    {
        // SceneManager.LoadScene("Sala4"); // Volta para a cena inicial
    }

    



}
