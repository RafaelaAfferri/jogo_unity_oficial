using UnityEngine;

public class Puzzle2_sala3 : MonoBehaviour
{

    public int[] resposta = new int[5];
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Texture spriteON;
    public Texture spriteOFF;
    public UnityEngine.UI.RawImage[] alavancaImagens;

    
    
    public void alavanca1(){
        resposta[0] = 1 - resposta[0]; // alterna entre 0 e 1
        alavancaImagens[0].texture = (resposta[0] == 1) ? spriteON : spriteOFF;
        Debug.Log("Alavanca 1 agora está em " + resposta[0]);
    }

    public void alavanca2(){
        resposta[1] = 1 - resposta[1]; // alterna entre 0 e 1
        alavancaImagens[1].texture = (resposta[1] == 1) ? spriteON : spriteOFF;
        Debug.Log("Alavanca 2 agora está em " + resposta[1]);
    }

    public void alavanca3(){
        resposta[2] = 1 - resposta[2]; // alterna entre 0 e 1
        alavancaImagens[2].texture = (resposta[2] == 1) ? spriteON : spriteOFF;
        Debug.Log("Alavanca 2 agora está em " + resposta[2]);
    }

    public void alavanca4(){
        resposta[3] = 1 - resposta[3]; // alterna entre 0 e 1
        alavancaImagens[3].texture = (resposta[3] == 1) ? spriteON : spriteOFF;
        Debug.Log("Alavanca 2 agora está em " + resposta[3]);
    }

    public void alavanca5(){
        resposta[4] = 1 - resposta[4]; // alterna entre 0 e 1
        alavancaImagens[4].texture = (resposta[4] == 1) ? spriteON : spriteOFF;
        Debug.Log("Alavanca 2 agora está em " + resposta[4]);
    }



    void Start()
    {

        resposta[0] = 1;
        resposta[1] = 1;
        resposta[2] = 1;
        resposta[3] = 1;
        resposta[4] = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
