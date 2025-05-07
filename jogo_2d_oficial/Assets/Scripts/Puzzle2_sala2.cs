using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Puzzle2_sala2 : MonoBehaviour
{
    public TextMeshProUGUI textoLivro;
    public TextMeshProUGUI textoFeedback;
    public TMP_InputField[] camposCodigo;

    private string respostaCorreta = "321525";

    public GameObject panel;
    public Button botaoAvancar;

    public void abrirLivro1()
    {
        textoLivro.text = "Três homens lutaram pelo duelo proibido. Apenas um foi enterrado.";
        textoLivro.gameObject.SetActive(true);
    }

    public void abrirLivro2()
    {
        textoLivro.text = "Dias após a doença, os aldeões começaram a rezar. Ela partiu antes do quinto sino.";
        textoLivro.gameObject.SetActive(true);
    }

    public void abrirLivro3()
    {
        textoLivro.text = "Mentiras encobriram o crime. O número foi alterado duas vezes.";
        textoLivro.gameObject.SetActive(true);
    }

    public void abrirLivro4()
    {
        textoLivro.text = "Os documentos estavam datados de maio. A chave estava escrita com tinta vermelha no rodapé.";
        textoLivro.gameObject.SetActive(true);
    }

    public void Verificar()
    {
        string codigoDigitado = "";
        foreach (var campo in camposCodigo)
        {
            codigoDigitado += campo.text;
        }

        if (codigoDigitado == respostaCorreta)
        {
            textoFeedback.text = "Correto!";
            textoFeedback.gameObject.SetActive(true);
            botaoAvancar.gameObject.SetActive(true);
        }
        else if (System.Text.RegularExpressions.Regex.IsMatch(codigoDigitado, @"[a-zA-Z]"))
        {
            textoFeedback.text = "A resposta não deve conter letras.";
            textoFeedback.gameObject.SetActive(true);
        }
        else if (codigoDigitado.Length == 6)
        {
            textoFeedback.text = "Não parece estar certo...";
            textoFeedback.gameObject.SetActive(true);
        }
        else
        {
            textoFeedback.text = "Ainda há números perdidos....";
            textoFeedback.gameObject.SetActive(true);
        }
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Cena Ana"); // Volta para a cena inicial

        foreach (var campo in camposCodigo)
        {
            campo.text = "";
        }


    }

    public void Avancar()
    {
        SceneManager.LoadScene("Cena Ana"); // Volta para a cena inicial
        Debug.Log("Avançar para a próxima parte do jogo!");
    }
}
