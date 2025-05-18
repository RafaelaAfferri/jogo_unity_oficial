using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HudVidaController : MonoBehaviour
{
    public static HudVidaController Instance; // Singleton

    public Sprite coracaoCheio;
    public Sprite coracaoVazio;
    public GameObject coracaoPrefab;
    public int maxVidas = 7;
    public int vidasAtuais = 7;

    private List<Image> coracoes = new List<Image>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicatas
        }
    }

    void Start()
    {
        CriarHUD();
    }

    void CriarHUD()
    {
        for (int i = 0; i < maxVidas; i++)
        {
            GameObject c = Instantiate(coracaoPrefab, transform);
            Image img = c.GetComponent<Image>();
            img.sprite = coracaoCheio;
            coracoes.Add(img);
        }

        AtualizarHUD();
    }

    public void PerderVida()
    {
        if (vidasAtuais <= 0) return;

        vidasAtuais--;
        AtualizarHUD();
    }

    public void AtualizarHUD()
    {
        for (int i = 0; i < coracoes.Count; i++)
        {
            coracoes[i].sprite = i < vidasAtuais ? coracaoCheio : coracaoVazio;
        }
    }

    public void ResetarVidas()
    {
        vidasAtuais = maxVidas;
        AtualizarHUD();
    }

    
    
}

