using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Alvo a ser seguido")]
    public Transform player;

    [Header("Suavização")]
    [Tooltip("Tempo que a câmera leva para alcançar o alvo")]
    public float smoothTime = 0.3f;

    private Vector3 _velocity = Vector3.zero;
    private float _fixedZ;

    void Awake()
    {
        // guarda o Z original da câmera para não alterá-lo
        _fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player == null) return;

        // define a posição alvo sempre centralizando o player
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, _fixedZ);

        // move suavemente a câmera até a posição alvo
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTime);
    }
}