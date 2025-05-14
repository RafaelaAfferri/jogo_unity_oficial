using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    public GameObject panel; 
    public GameObject slotPrefab;
    public int numberOfSlots = 5;
    public GameObject[] texts; 

    // Adicione esta lista
    public List<Slot> slotsCriados = new List<Slot>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextMeshProUGUI textoAnoMorte = null; // Variável para guardar a referência

        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot slot = Instantiate(slotPrefab, panel.transform).GetComponent<Slot>(); // Cria o slot e obtém o componente Slot
            slot.slotId = i; // Atribui um ID ao slot
            slotsCriados.Add(slot);
            if (i < texts.Length)
            {
                GameObject item = Instantiate(texts[i], slot.transform); // Cria o item dentro do slot
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Define a posição do item dentro do slot
                slot.currentItem = item; // Atribui o item ao slot
                if (textoAnoMorte == null){
                    
                    TextMeshProUGUI[] textos = item.GetComponentsInChildren<TextMeshProUGUI>(true);
                    foreach (var texto in textos)
                    {
                        if (texto.CompareTag("anoMorte"))
                        {
                            textoAnoMorte = texto;
                            break;
                        }
                    }
                }
            }


        }
        // Passa para o PuzzleManager
        PuzzleManager puzzle = FindFirstObjectByType<PuzzleManager>();
        if (puzzle != null)
        {
            puzzle.DefinirSlots(slotsCriados.ToArray());
            if (textoAnoMorte != null)
            {
                puzzle.anoMorte = textoAnoMorte;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
