using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    // vetor de movimento atual e último vetor não-zero
    private Vector2 movement;
    private Vector2 lastMovement = Vector2.down; // valor inicial: olhando para baixo

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1) ler input bruto
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // 2) se houver movimento, atualiza o lastMovement
        if (movement != Vector2.zero)
            lastMovement = movement.normalized;

        // 3) usa lastMovement pra dirigir o Blend Tree
        animator.SetFloat("MoveX", lastMovement.x);
        animator.SetFloat("MoveY", lastMovement.y);

        // 4) Speed continua usando movement real pra transição Idle/Walk
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // movimento físico: normaliza o vetor só pra manter velocidade constante
        if (movement != Vector2.zero)
        {
            Vector2 desloc = movement.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + desloc);
        }
    }
}