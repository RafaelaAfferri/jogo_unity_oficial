using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SecretDoorProximity : MonoBehaviour
{
    [Header("Configurações de proximidade")]
    [Tooltip("Distância em unidades para disparar a animação de abertura")]
    public float openDistance = 2f;

    [Header("Animator")]
    [Tooltip("O Animator que contém o trigger de abertura")]
    public Animator animator;
    [Tooltip("Nome exato do parâmetro Trigger no Animator")]
    public string openTrigger = "OpenSecretDoor";

    private Transform player;
    private bool hasOpened;

    void Start()
    {
        // Busca o player pela tag; ajuste se o seu player usar outra tag
        var go = GameObject.FindGameObjectWithTag("Player");
        if (go != null) player = go.transform;
        else Debug.LogWarning("SecretDoorProximity: nenhum objeto com tag 'Player' foi encontrado.");
    }

    void Update()
    {
        if (hasOpened || player == null) return;

        float distance = Vector2.Distance(player.position, transform.position);
        if (distance <= openDistance)
        {
            animator.SetTrigger(openTrigger);
            hasOpened = true;
        }
    }

    // (Opcional) Desenha o raio de abertura na Scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, openDistance);
    }
}