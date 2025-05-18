using UnityEngine;
using UnityEngine.EventSystems;

public class Disco : MonoBehaviour, IPointerClickHandler
{
    public float anguloPorClique = 45f; // gira 45 graus por clique
    private int estadoAtual = 0;
    public int estadoCorreto = 3; // por exemplo, 3x45 = 135 graus

    public void OnPointerClick(PointerEventData eventData)
    {
        estadoAtual = (estadoAtual + 1) % (360 / (int)anguloPorClique);
        transform.Rotate(Vector3.forward, -anguloPorClique);
        if (estadoAtual == 25)
        {
            estadoAtual = 1;
        }
    }

    public bool EstaCorreto()
    {
        return estadoAtual == estadoCorreto;
    }
}
